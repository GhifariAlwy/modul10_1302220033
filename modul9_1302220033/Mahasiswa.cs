﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMahasiswa
{
    public class Mahasiswa
    {
        public string Nama { get; set; }
        public string Nim { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
    }

    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaData = new List<Mahasiswa>()
        {
            new Mahasiswa { Nama = "Ghifari", Nim = "1302220033", Course = "KPL", Year = "2003" },
            new Mahasiswa { Nama = "Alan", Nim = "1302229070", Course = "PBO", Year = "2004" },
            new Mahasiswa {Nama = "Aldino", Nim = "1302224344", Course = "Basdat", Year = "2004"},
            new Mahasiswa {Nama = "Harits", Nim = "1302222656", Course = "Jarkom", Year = "2003"},
        };

        [HttpGet("/api/mahasiswa")]
        public IActionResult GetAllMahasiswa()
        {
            return Ok(mahasiswaData);
        }

        [HttpGet("/api/mahasiswa/{index}")]
        public IActionResult GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaData.Count)
            {
                return NotFound("Index tidak valid");
            }
            return Ok(mahasiswaData[index]);
        }

        [HttpPost("/api/mahasiswa")]
        public IActionResult AddMahasiswa([FromBody] Mahasiswa newMahasiswa)
        {
            if (newMahasiswa == null || string.IsNullOrEmpty(newMahasiswa.Nama) || string.IsNullOrEmpty(newMahasiswa.Nim) || string.IsNullOrEmpty(newMahasiswa.Course) || string.IsNullOrEmpty(newMahasiswa.Year));
            {
                return BadRequest("Nama dan NIM harus diisi");
            }

            mahasiswaData.Add(newMahasiswa);
            return CreatedAtRoute("GetMahasiswaByIndex", new { index = mahasiswaData.Count - 1 }, newMahasiswa);
        }

        [HttpDelete("/api/mahasiswa/{index}")]
        public IActionResult DeleteMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaData.Count)
            {
                return NotFound("Index tidak valid");
            }

            mahasiswaData.RemoveAt(index);
            return Ok("Mahasiswa dihapus");
        }
    }
}