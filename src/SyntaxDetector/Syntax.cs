using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxDetector {
    class Syntax : ICloneable {

        public List<SyntaxPart> parts = new List<SyntaxPart>();   

        public float GetTotalConfidence() {
            float res = 0;
            foreach(var part in parts) {
                res += part.confidence;
            }
            return res;
        }

        public float GetMinimalistConfidence() {
            float res = 0;
            foreach(var part in parts) {
                res += part.confidence == 0 ? -0.01f : part.confidence;
            }
            return res;
        }

        public void Clean() {
            var list = new List<SyntaxPart>();
            var buffer = new StringBuilder();
            for(var i = 0; i < parts.Count; i++) {
                if(parts[i].type == Type.Empty) {
                    buffer.Append(parts[i].startSequence);
                } else {
                    if(buffer.Length == 0) {
                        list.Add(parts[i]);
                    } else {
                        var element = (SyntaxPart) parts[i].Clone();
                        element.startSequence = buffer.ToString() + element.startSequence;
                        list.Add(element);
                        buffer.Clear();
                    }
                }
            }
            parts = list;
        }

        public Syntax GetDowngrade() {
            foreach(var part in parts) {
                if(part.type == Type.Class || part.type == Type.Function) {
                    var result = (Syntax) Clone();
                    result.parts.Clear();
                    foreach (var p in parts) {
                        if (p.type == Type.Class || p.type == Type.Function) {
                            var np = (SyntaxPart) p.Clone();
                            np.type = Type.Message;
                            result.parts.Add(np);
                        } else {
                            result.parts.Add(p);
                        }
                    }
                    return result;
                }
            }
            return null;
        }

        public object Clone() {
            var clone = new Syntax();
            foreach(var part in parts) {
                clone.parts.Add((SyntaxPart) part.Clone());
            }
            return clone;
        }

        public override bool Equals(object obj) {
            if (obj.GetType() != this.GetType()) return false;
            var o = (Syntax)obj;
            if (o.parts.Count != parts.Count) return false;
            for(var i = 0; i < parts.Count; i++) {
                if (!o.parts[i].Equals(parts[i])) return false;
            }
            return true;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            var msgs = 0;
            foreach(var part in parts) {
                if (part.type == Type.Message) msgs++;
            }
            var ctx = 0;
            for(var i = 0; i < parts.Count; i++) {
                var part = parts[i];
                var nextPart = i < parts.Count - 1 ? parts[i + 1] : null;
                sb.Append(part.GetSyntaxString(nextPart != null ? nextPart.startSequence : "1", ctx == msgs - 1 ? 0 : ctx));
                if (part.type == Type.Message) ctx++;
                if(i < parts.Count - 1) sb.Append(" ");
            }
            return sb.ToString();
        }

    }
}
