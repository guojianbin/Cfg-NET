using Transformalize.Libs.Cfg;

namespace Cfg.Test.TestClasses {
    public class MethodSite : CfgNode {
        public MethodSite() {
            Property(name: "name", value: "", required: true, unique: true);
            Property(name: "url", value: "", required: true);
            Property(name: "something", value: "", decode: true);
            Property(name: "numeric", value: 0);
        }
    }
}