using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IWeaponService
    {
        ICollection<WeaponEntity> GetWeapons();
        WeaponEntity PostWeapon(WeaponEntity weapon);
        WeaponEntity UpdateWeapon(WeaponEntity weapon, string displayName);
        WeaponEntity RemoveWeapon(string displayName);
    }
    public class WeaponService:IWeaponService
    {
        private readonly IAppStore _appDbContext;
        private readonly AppDbContext _dbContext;
        public WeaponService(IAppStore appDbContext,
                             AppDbContext dbContext)
        {
            _appDbContext = appDbContext;
            _dbContext = dbContext;
        }

        public ICollection<WeaponEntity> GetWeapons()
        {
            var weapons = _dbContext.Weapons.ToList();
            return weapons;
        }

        public WeaponEntity PostWeapon(WeaponEntity weapon)
        {
            _dbContext.Weapons.Add(weapon);
            _dbContext.SaveChanges();
            return weapon;
        }

        public WeaponEntity UpdateWeapon(WeaponEntity weapon, string displayName)
        {
            var oldWeapon = _dbContext.Weapons.FirstOrDefault(w => w.displayName == displayName);

            if (oldWeapon == null)
            {
                return null;
            }

            oldWeapon.displayName = weapon.displayName;
            oldWeapon.description = weapon.description;
            _dbContext.SaveChanges();

            return oldWeapon;
        }

        public WeaponEntity RemoveWeapon(string displayName)
        {
            var removedWeapon = _dbContext.Weapons.FirstOrDefault(w => w.displayName == displayName);

            if (removedWeapon == null)
            {
                return null;
            }

            _dbContext.Weapons.Remove(removedWeapon);
            _dbContext.SaveChanges();

            return removedWeapon;
        }
    }
}
