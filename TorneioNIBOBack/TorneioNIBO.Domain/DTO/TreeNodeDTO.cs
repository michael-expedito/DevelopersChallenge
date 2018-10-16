using System.Collections.Generic;

namespace TorneioNIBO.Domain.DTO
{
    public class TreeNodeDTO
    {
        public string label { get; set; }
        public bool expanded { get; set; }
        public List<TreeNodeDTO> children { get; set; }
    }
}
