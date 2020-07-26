using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackPrueba.Context;
using BackPrueba.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuarioController : ControllerBase
    {
        private readonly AppDbContext context;
        public usuarioController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: api/usuario
        [HttpGet]
        public ActionResult<List<usuario>> Get()
        {
            try
            {
                return context.usuario.ToList();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // GET: api/usuario/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<usuario> Get(int id)
        {
            try
            {
                var res_usuario = context.usuario.Find(id);
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

       
        // POST: api/usuario
        [HttpPost]
        public ActionResult Post([FromBody] usuario Usuario)
        {
            try
            {
                context.usuario.Add(Usuario); //Pasamos el objeto Usuario que sera el encargado de insertar en la bd
                context.SaveChanges(); //guardamos cambios
                return Ok();//indica que todo salio bien y la la informacion se guardo correctamente
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message); //indica que todo salio bien y la la informacion se guardo correctamente
            }
        }
        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] usuario Usuario)
        {
                if (Usuario.Id_usuario == id)
                {
                    context.usuario.Update(Usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok();
                }
                else {
                    return BadRequest();
                }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Usuario = context.usuario.Find(id);
                if (Usuario == null) //se validad si el registro fue encontrado
                {
                    return NotFound();
                }
                context.Remove(Usuario); //remueva o elimina el registro encontrado
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
