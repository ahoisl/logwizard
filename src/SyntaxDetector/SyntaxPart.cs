using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxDetector {
    class SyntaxPart : ICloneable {

        public Type type = Type.Empty;
        public string startSequence = "";
        public float confidence = 0f;

        public object Clone() {
            return new SyntaxPart {
                type = this.type,
                startSequence = (string) this.startSequence.Clone(),
                confidence = this.confidence
            };
        }

        public string GetSyntaxString(string endSequence = "0", int ctx = 0) {
            StringBuilder sb = new StringBuilder();
            sb.Append("$");
            switch (type) {
                case Type.Class:
                    sb.Append("class");
                    break;
                case Type.Date:
                    sb.Append("date");
                    break;
                case Type.File:
                    sb.Append("file");
                    break;
                case Type.Function:
                    sb.Append("func");
                    break;
                case Type.Level:
                    sb.Append("level");
                    break;
                case Type.Message:
                    if (ctx != 0) sb.Append("ctx" + ctx);
                    else sb.Append("msg");
                    break;
                case Type.Time:
                    sb.Append("time");
                    break;
            }

            if(endSequence != "1") {
                if (startSequence == "0") {
                    sb.Append("[0");
                } else {
                    sb.Append("[''");
                }
                sb.Append(",'");
                sb.Append(endSequence);
                sb.Append("']");
            }
            return sb.ToString();
        }

        public override bool Equals(object obj) {
            if (obj.GetType() != this.GetType()) return false;
            var o = (SyntaxPart)obj;
            return o.type == type && o.startSequence == startSequence;
        }

        public override string ToString() {
            return type.ToString() + " (" + startSequence + "-" + confidence + ")";
        }

    }
}
