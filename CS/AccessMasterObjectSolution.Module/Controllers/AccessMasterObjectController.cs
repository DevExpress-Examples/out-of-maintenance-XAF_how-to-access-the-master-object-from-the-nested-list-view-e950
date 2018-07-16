using DevExpress.ExpressApp;

namespace AccessMasterObjectSolution.Module {
    public class AccessMasterObjectController : ViewController<ListView> {
        private void UpdateMasterObject(object masterObject) {
            MyPerson MasterObject = (MyPerson)masterObject;
            //Use the master object as required            
        }
        private void OnMasterObjectChanged(object sender, System.EventArgs e) {
            UpdateMasterObject(((PropertyCollectionSource)sender).MasterObject);
        }
        protected override void OnActivated() {
            base.OnActivated();
            PropertyCollectionSource collectionSource = View.CollectionSource as PropertyCollectionSource;
            if (collectionSource != null) {
                collectionSource.MasterObjectChanged += OnMasterObjectChanged;
                if (collectionSource.MasterObject != null)
                    UpdateMasterObject(collectionSource.MasterObject);
            }
        }
        protected override void OnDeactivated() {
            PropertyCollectionSource collectionSource = View.CollectionSource as PropertyCollectionSource;
            if (collectionSource != null) {
                collectionSource.MasterObjectChanged -= OnMasterObjectChanged;
            }
            base.OnDeactivated();
        }
        public AccessMasterObjectController() {
            TargetViewNesting = Nesting.Nested;
            TargetObjectType = typeof(MyTask);
        }
    }
}
