namespace XyAuto.It.Web.Areas.AppAreaName.Models.Common
{
    public class OrganizationUnitTreeItemModel
    {
        public IOrganizationUnitsEditViewModel EditModel { get; set; }

        public long? ParentId { get; set; }

        public OrganizationUnitTreeItemModel()
        {

        }

        public OrganizationUnitTreeItemModel(IOrganizationUnitsEditViewModel editModel, long? parentId)
        {
            EditModel = editModel;
            ParentId = parentId;
        }
    }
}
