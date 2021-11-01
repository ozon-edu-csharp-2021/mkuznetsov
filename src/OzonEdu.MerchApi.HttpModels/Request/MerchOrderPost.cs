using CSharpCourse.Core.Lib.Enums;

namespace OzonEdu.MerchApi.HttpModels.Request
{
    public class MerchOrderPost
    {
        public long EmployeeId { get; set; }
        
        public MerchType MerchType { get; set; }
    }
}