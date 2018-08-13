using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxDetector {
    class Detection {

        public List<DetectionGroup> groups = new List<DetectionGroup>();

        public string content;
        public int startIndex;
        public char[] separatorStack;
        public int position;

        public Type type;
        public float confidence;

        public Detection(string content, int startIndex = 0, char separator = '0', int position = 0, char[] separatorStack = null) {
            this.content = content;
            this.startIndex = startIndex;
            this.position = position;
            if(separatorStack == null) {
                this.separatorStack = new char[1];
            } else {
                this.separatorStack = new char[separatorStack.Length + 1];
                separatorStack.CopyTo(this.separatorStack, 0);
            }
            this.separatorStack[this.separatorStack.Length - 1] = separator;

            var parsed = Parse(content);
            type = parsed.type;
            confidence = parsed.confidence;

            MakeChildren();
        }

        private void MakeChildren() {
            foreach(var separator in SyntaxDetector.SEPARATORS) {
                var parts = content.Split(separator);
                if(parts.Length > 1) {
                    var group = new DetectionGroup();
                    int calculatedStart = 0;
                    var position = 0;
                    foreach(var part in parts) {
                        group.children.Add(new Detection(part, calculatedStart, separator, position++, separatorStack));
                        calculatedStart += startIndex + part.Length + 1;
                    }
                    groups.Add(group);
                }
            }
        }

        private (Type type, float confidence) Parse(string input) {
            input = input.Trim();
            List<(Type type, float confidence)> types = new List<(Type type, float confidence)>();

            if (string.IsNullOrEmpty(input)) return (Type.Empty, 0);

            // Level
            int levelScore = 0, maxLevelScore = 1;
            foreach(var level in SyntaxDetector.LEVELS) {
                if(input.ToUpper() == level) {
                    levelScore++;
                }
            }
            types.Add((Type.Level, (float) levelScore / maxLevelScore));

            // Time
            int timeScore = 0, maxTimeScore = 4;
            if(DateTime.TryParse(input.Replace(",", "."), out var time)) {
                timeScore++;
                if(!input.Contains(time.Month.ToString("D2")) 
                    || !input.Contains(time.Day.ToString("D2"))) {
                    timeScore++;
                }
                if(input.Contains(time.Hour.ToString("D2")) && input.Contains(time.Minute.ToString("D2")) && input.Contains(time.Second.ToString("D2"))) {
                    timeScore++;
                }
                if(input.Contains(time.Millisecond.ToString("D3"))) {
                    timeScore++;
                }
            }
            types.Add((Type.Time, (float)timeScore / maxTimeScore));

            // Date
            int dateScore = 0, maxDateScore = 3;
            if(DateTime.TryParse(input, out var date)) {
                dateScore++;
                if (input.Contains(time.Month.ToString("D2")) && input.Contains(time.Day.ToString("D2"))) {
                    dateScore++;
                }
                if (!input.Contains(time.Hour.ToString("D2")) || !input.Contains(time.Minute.ToString("D2")) || !input.Contains(time.Second.ToString("D2"))) {
                    dateScore++;
                }
            }
            types.Add((Type.Date, (float)dateScore / maxDateScore));

            // File
            int fileScore = 0, maxFileScore = 4;
            if(input.Length > 3) {
                var temp = input.Replace("\\", "/");
                if(char.IsLetter(temp[0]) && temp[1] == ':' && temp[2] == '/') {
                    // Path to file on Windows
                    fileScore++;
                }
                if (input[0] == '/' || temp[2] == '/') {
                    // Also includes OS besides Windows
                    fileScore++;
                }
                var pathParts = temp.Split('/');
                if (pathParts[pathParts.Length - 1].Contains(".")) {
                    fileScore++;
                }

                if(fileScore > 0 && pathParts.Length > 2) {
                    var contains = false;
                    foreach (var reserved in SyntaxDetector.RESERVEDCHARS) {
                        for(var i = 1; i < pathParts.Length - 1; i++) {
                            if (pathParts[i].Contains(reserved)) {
                                contains = true;
                                goto POSTLOOP; // Why would C# not let me break at a label instead of this...
                            }
                        }
                    }
                    POSTLOOP:
                    if (!contains) {
                        fileScore++;
                    }
                }
            }
            types.Add((Type.File, (float)fileScore / maxFileScore));

            // Class
            // TODO

            // Function
            // Can't really detect this

            // Message/ctx

            float highestConfidence = 0;
            Type high = Type.Message;
            foreach(var type in types) {
                if(type.confidence > highestConfidence) {
                    highestConfidence = type.confidence;
                    high = type.type;
                }
            }
            
            return highestConfidence >= .75f ? (high, highestConfidence) : (Type.Message, 0);
        }

        private void BuildString(StringBuilder sb, int depth = 0, Nullable<Type> filter = null) {
            if(!filter.HasValue || type == filter) {
                for (var i = 0; i < depth; i++) sb.Append(" ");
                sb.Append(content);
                sb.Append(" (");
                sb.Append(type.ToString());
                sb.Append(" - ");
                sb.Append(confidence);
                sb.Append(")");
                sb.AppendLine();
            }
            foreach(var group in groups) {
                foreach(var child in group.children) {
                    child.BuildString(sb, depth + 1, filter);
                }
            }
        }

        public List<Syntax> GenerateSyntaxes() {
            var list = new List<Syntax>();

            list.Add(new Syntax {
                parts = new List<SyntaxPart>() { this.ToSyntaxPart() }
            });

            foreach (var group in groups) {
                list.AddRange(group.ToSyntax());
            }

            return list;
        }

        public SyntaxPart ToSyntaxPart() {
            char startChar = '0';
            if(position == 0) {
                if(separatorStack.Length >= 2) {
                    startChar = separatorStack[separatorStack.Length - 2];
                }
            } else {
                startChar = separatorStack[separatorStack.Length - 1];
            }
            return new SyntaxPart {
                type = this.type,
                startIndex = this.startIndex,
                endIndex = this.startIndex + content.Length,
                startSequence = startChar.ToString(),
                confidence = this.confidence
            };
        }

        public override string ToString() {
            var sb = new StringBuilder();
            BuildString(sb);
            return sb.ToString();
        }

    }
}
