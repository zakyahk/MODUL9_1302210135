using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace MODUL9_1302210135
{
    [Route("api/[controller]")]
    [ApiController]
    public class MahasiswaController : ControllerBase
    {
        // Data dummy untuk contoh
        private static List<Mahasiswa> _mahasiswaData = new List<Mahasiswa>()
        {
            new Mahasiswa("Zakkiya Hakeem", "1302210135", "Konstruksi Perangkat Lunak" , "1" , 2019),
            new Mahasiswa("Hafid Naoya", "1302210028", "Konstruksi Perangkat Lunak" , "2" , 2019)
       
        };

        public string nim { get; private set; }

        // GET api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return _mahasiswaData;
        }

        // GET api/mahasiswa/1302210135
        [HttpGet("{id}")]
        public ActionResult<Mahasiswa> GetMahasiswaByNim(int id)
        {
            var mahasiswa = _mahasiswaData.FirstOrDefault(m => m.Nim == nim);
            if (mahasiswa == null)
            {
                return NotFound();
            }
            return mahasiswa;
        }

        // POST api/mahasiswa
        [HttpPost]
        public ActionResult<Mahasiswa> AddMahasiswa(Mahasiswa mahasiswa)
        {
            _mahasiswaData.Add(mahasiswa);
            return Ok(_mahasiswaData);//CreatedAtAction(nameof(GetMahasiswaByNim), new { nim = mahasiswa.Nim }, mahasiswa);
        }

        // DELETE api/mahasiswa/1302210135
        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            var existingMahasiswa = _mahasiswaData.FirstOrDefault(m => m.Nim == nim);
            if (existingMahasiswa == null)
            {
                return NotFound();
            }
            _mahasiswaData.Remove(existingMahasiswa);
            return NoContent();
        }
    }

    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
        public string Course { get; internal set; }
        public string id { get; internal set; }
        public int Year { get; internal set; }
        public Mahasiswa(string Nama, string Nim, string Course, string id, int Year)
        {
            this.Nama = Nama;
            this.Nim = Nim;
            this.Course = Course;
            this.id = id;
            this.Year = Year;
        }
    }

}

