using DevExpress.ExpressApp;

namespace AccessMasterObjectSolution.Module {
    public class AccessMasterObjectController : ViewController<ListView> {
        public AccessMasterObjectController() {
            TargetViewNesting = Nesting.Nested;
            TargetObjectType = typeof(MyTask);
		}
        protected override void OnActivated() {
            base.OnActivated();
            if(View.CollectionSource is PropertyCollectionSource) {
                PropertyCollectionSource collectionSource = (PropertyCollectionSource)View.CollectionSource;
                collectionSource.MasterObjectChanged += OnMasterObjectChanged;
                if (collectionSource.MasterObject != null)
                    UpdateMasterObject(collectionSource.MasterObject);
            }
        }
        void UpdateMasterObject(object masterObject) {
            MyPerson MasterObject = (MyPerson)masterObject;
            //Use the master object as required            
        }
        void OnMasterObjectChanged(object sender, System.EventArgs e) {
            UpdateMasterObject(((PropertyCollectionSource)sender).MasterObject);
        }
        protected override void OnDeactivated() {
            if (View.CollectionSource is PropertyCollectionSource) {
                PropertyCollectionSource collectionSource = (PropertyCollectionSource)View.CollectionSource;
                collectionSource.MasterObjectChanged -= OnMasterObjectChanged;
            }
            base.OnDeactivated();
        }
    }
}
