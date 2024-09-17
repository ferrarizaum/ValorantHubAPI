using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IWeaponService
    {
        ICollection<WeaponEntity> GetWeapons();
    }
    public class WeaponService:IWeaponService
    {
        private readonly IAppStore _appDbContext;
        public WeaponService(IAppStore appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<WeaponEntity> GetWeapons()
        {
            Console.WriteLine("Inside GetWeapons");
            var weapons = _appDbContext.Weapons.ToList();
            return weapons;
        }
    }
}
