using System;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace AccessMasterObjectSolution.Module {
    [DefaultClassOptions]
    public class MyPerson : Person {
        public MyPerson(Session session) : base(session) { }
        [Association("Person-Tasks", typeof(MyTask))]
        public XPCollection Tasks {
            get { return GetCollection("Tasks"); }
        }
    }
    [DefaultClassOptions]
    public class MyTask : Task {
        public MyTask(Session session) : base(session) { }
        private MyPerson myPerson;
        [Association("Person-Tasks", typeof(MyPerson))]
        public MyPerson MyPerson {
            get { return myPerson; }
            set { SetPropertyValue("MyPerson", ref myPerson, value); }
        }
    }
}
