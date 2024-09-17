using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IWeaponService
    {
        ICollection<WeaponEntity> GetWeapons();
        WeaponEntity PostWeapon(WeaponEntity weapon);
        WeaponEntity UpdateWeapon(WeaponEntity weapon, string displayName);

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
            var weapons = _appDbContext.Weapons.ToList();
            return weapons;
        }

        public WeaponEntity PostWeapon(WeaponEntity weapon)
        {
            _appDbContext.Weapons.Add(weapon);
            return weapon;
        }

        public WeaponEntity UpdateWeapon(WeaponEntity weapon, string displayName)
        {
            var oldWeapon = _appDbContext.Weapons.Find(a => a.displayName == displayName);

            if (oldWeapon == null)
            {
                return null;
            }

            oldWeapon.displayName = weapon.displayName;
            oldWeapon.description = weapon.description;

            return oldWeapon;
        }
    }
}
