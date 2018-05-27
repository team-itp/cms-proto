using System.Collections.Generic;

namespace CmsClient.Models
{
    public class PurchaseOrder
    {
        public string No { get; set; }
        public string Name { get; set; }

        public IEnumerable<Tag> TagsForPurchaseOrder { get; set; }
    }
}
