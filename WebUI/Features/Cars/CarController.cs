using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Features.Cars
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllersBaseClass
    {
        public CarController(ApplicationDbContext db):base(db)
        {

        }

        [HttpGet]
        public async Task <ActionResult<List<Car>>> GetCars()
        {
            var cars = await context.Cars.ToListAsync();
            if (cars.Count<=0)
            {
                return NotFound("Database doesn't contain data");
            }
            return Ok(cars);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            var car1 = await context.Cars.FirstOrDefaultAsync(e => e.Id == id);
            if (car1==null)
            {
                return NotFound(string.Format("Car with Id {0} doesn't exist",id));
            }
            return Ok(car1);
        }
        
        [HttpPost]
        public async Task<ActionResult<Car>> GetCarById(Car car)
        {
            try
            {
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest($"Couldn't save the car you entered because {ex.Message}");
            }
            return Created(Url.ActionLink("GetCarById","Car",car.Id),car);
        }

    }
}
