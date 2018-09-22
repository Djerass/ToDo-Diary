using System.Security.Claims;

namespace Diary.Models
{
    public interface Iid
    {
         string TakaId(ClaimsPrincipal User);
    }
    public class ForId : Iid
    {
        public string TakaId(ClaimsPrincipal User)
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
