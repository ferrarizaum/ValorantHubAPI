using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var weapons = _weaponService.GetWeapons(); 
            return Ok(weapons);
        }

        [HttpPost]
        public IActionResult Post([FromBody] WeaponEntity weapon)
        {
            var newWeapon =_weaponService.PostWeapon(weapon);
            return Ok(newWeapon);
        }

        [HttpPut]
        public IActionResult Put([FromBody] WeaponEntity weapon, string displayName)
        {
            var updatedWeapon = _weaponService.UpdateWeapon(weapon, displayName);
            return Ok(updatedWeapon);
        }

        [HttpDelete]
        public IActionResult Delete(string displayName)
        {
            var removedWeapon = _weaponService.RemoveWeapon(displayName);
            return Ok(removedWeapon);
        }
    }
}
