using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackPrueba.Context;
using BackPrueba.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class perfilesController : ControllerBase
    {
        private readonly AppDbContext context;

        public perfilesController( AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/<perfilesController>
        [HttpGet]
        public ActionResult<List<perfiles>> Get()
        {
            try
            {
                return context.perfil.ToList();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET api/<perfilesController>/5
        [HttpGet("{id}")]
        public ActionResult<perfiles> Get(int id)
        {
            try
            {
                var res_usuario = context.perfil.Find(id);
                if (res_usuario == null)
                {
                    return NotFound(); //retorna  NotFound si en su busqueda no encuentr resultados
                }
                return Ok(res_usuario); //retorna lo encontrado segun el ID
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); //indica que todo salio bien y la la informacion se guardo correctamente
            }
        }

        // POST api/<perfilesController>
        [HttpPost]
        public ActionResult Post([FromBody] perfiles perfiles)
        {
            try
            {
                context.perfil.Add(perfiles); //Pasamos el objeto Usuario que sera el encargado de insertar en la bd
                context.SaveChanges(); //guardamos cambios
                return Ok();//indica que todo salio bien y la la informacion se guardo correctamente
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); //indica que todo salio bien y la la informacion se guardo correctamente
            }
        }

        // PUT api/<perfilesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] perfiles Perfiles)
        {
            if (Perfiles.id_perfil == id)
            {
                context.perfil.Update(Perfiles).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<perfilesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Perfi = context.usuario.Find(id);
                if (Perfi == null) //se validad si el registro fue encontrado
                {
                    return NotFound();
                }
                context.Remove(Perfi); //remueva o elimina el registro encontrado
                context.SaveChanges(); //Se guardan los cambios
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
