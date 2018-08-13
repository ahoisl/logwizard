using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxDetector {
    class DetectionGroup {

        public List<Detection> children = new List<Detection>();

        public List<Syntax> ToSyntax() {
            var syntax = new List<Syntax>();

            syntax.Add(new Syntax());
            foreach (var child in children) {
                syntax[0].parts.Add(child.ToSyntaxPart());
            }

            var replacements = new List<List<List<Syntax>>>(); // Detection -> Group -> Syntax
            foreach(var child in children) {
                var entry = new List<List<Syntax>>();
                foreach(var group in child.groups) {
                    entry.Add(group.ToSyntax());
                }
                replacements.Add(entry);
            }

            for (var i = 0; i < syntax[0].parts.Count; i++) {
                foreach(var replacement in replacements[i]) {
                    foreach(var rep in replacement) {
                        var clone = (Syntax)syntax[0].Clone();
                        clone.parts.RemoveAt(i);
                        clone.parts.InsertRange(i, rep.parts);
                        syntax.Add(clone);
                    }
                }
            }

            /*var replacements = new List<List<List<Syntax>>>(); // Detection -> Group -> Syntax
            foreach (var child in children) {
                var entry = new List<List<Syntax>>();
                foreach (var group in child.groups) {
                    entry.Add(group.ToSyntax());
                }
                replacements.Add(entry);
            }

            GenerateCombinations(syntax[0].parts.Count, syntax[0], replacements, syntax);*/

            return syntax;
        }

        private void GenerateCombinations(int children, Syntax current, List<List<List<Syntax>>> replacements, List<Syntax> result, int position = 0, int added = 0) {
            var repl = replacements[position];
            foreach (var rep in repl) {
                foreach (var replacement in rep) {
                    var replaced = (Syntax)current.Clone();
                    var add = replacement.parts.Count - 1;
                    replaced.parts.RemoveAt(position + added);
                    replaced.parts.InsertRange(position + added, replacement.parts);
                    result.Add(replaced);
                    if(position < children - 1) {
                        GenerateCombinations(children, replaced, replacements, result, position + 1, add + added);
                    }
                }
            }
        }

    }
}
