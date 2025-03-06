using System.ComponentModel.DataAnnotations.Schema;

namespace FDS.CRM.Domain.Entities
{
    [Table("AssociatedInfo")]
    public class AssociatedInfo : Entity<Guid>, IAggregateRoot
    {
        public Guid ObjectReferenceId { get; private set; }
        public string Value { get; private set; }
        public AssociatedInfoType AssociatedInfoType { get; private set; }
        public AssociatedObjectType ObjectType { get; private set; }

        #region Constructor
        private AssociatedInfo(Guid objectReferenceId, string value,
                               AssociatedInfoType associatedInfoType, AssociatedObjectType objectType)
        {
            Id = Guid.NewGuid();
            ObjectReferenceId = objectReferenceId;
            Value = value;
            AssociatedInfoType = associatedInfoType;
            ObjectType = objectType;
        }
        #endregion

        #region Business Logic
        public static AssociatedInfo Create(Guid objectReferenceId, string value,
                                            AssociatedInfoType associatedInfoType, AssociatedObjectType objectType)
        {
            return new AssociatedInfo(objectReferenceId, value, associatedInfoType, objectType);
        }
        #endregion
    }
}
