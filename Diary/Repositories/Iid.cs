using System.Security.Claims;

namespace Diary.Models
{
    public interface Iid
    {
         string TakeId(ClaimsPrincipal User);
    }
    public class ForId : Iid
    {
        public string TakeId(ClaimsPrincipal User)
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
