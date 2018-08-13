using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxDetector {
    public class SyntaxDetector {

        public static readonly char[] SEPARATORS = new char[] { ' ', '\t', '|', ':', ';', '\\', '/', '<', '>', '-', ',' };
        public static readonly string[] LEVELS = new string[] { "INFO", "ERROR", "FATAL", "DEBUG", "WARN" };
        public static readonly char[] RESERVEDCHARS = new char[] { '<', '>', ':', '"', '|', '?', '*' };

        public string DetectSyntax(string[] lines) {
            var masterSyntax = new List<Syntax>();
            var allSyntax = new List<List<Syntax>>();
            foreach(var line in lines) {
                if (line.StartsWith(" ") || line.StartsWith("\t") || line.Trim().Length == 0) continue;

                var tree = new Detection(line);
                var syntax = tree.GenerateSyntaxes();
                syntax.ForEach(s => s.Clean());
                for(var i = 0; i < syntax.Count; i++) {
                    for(var k = i - 1; k >= 0; k--) {
                        if(syntax[i].Equals(syntax[k])) {
                            syntax.RemoveAt(k);
                            i--;
                        }
                    }
                }

                allSyntax.Add(syntax);
            }

            // Merge for all lines
            if(allSyntax.Count > 0) {
                for(var i = allSyntax[0].Count - 1; i >= 1; i--) {
                    var currentElement = allSyntax[0][i];
                    var foundCount = 1;
                    for(var j = 1; j < allSyntax.Count; j++) {
                        var found = false;
                        for(var k = allSyntax[j].Count - 1; k >= 0; k--) {
                            var otherElement = allSyntax[j][k];
                            if(otherElement.Equals(currentElement)) {
                                found = true;
                                break;
                            }
                        }
                        if(found) foundCount++;
                    }
                    if (((float) foundCount / allSyntax.Count) < 0.8f) allSyntax[0].RemoveAt(i);
                }
                masterSyntax = allSyntax[0];
            }

            // Find best syntax
            if(masterSyntax.Count > 0) {
                var bestSyntax = masterSyntax[0];
                var confidence = masterSyntax[0].GetMinimalistConfidence();
                foreach (var syntax in masterSyntax) {
                    if (syntax.GetMinimalistConfidence() > confidence) {
                        bestSyntax = syntax;
                        confidence = bestSyntax.GetMinimalistConfidence();
                    }
                }

                return bestSyntax.ToString();
            } else {
                return null;
            }
        }

    }
}
