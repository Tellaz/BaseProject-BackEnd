﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.DAO.Models
{
    [Index("IdRepresentante", Name = "IX_Empresa_IdRepresentante")]
    [Index("Dominio", Name = "UQ_Empresa_Dominio", IsUnique = true)]
    public partial class Empresa
    {
        public Empresa()
        {
            Download = new HashSet<Download>();
            Upload = new HashSet<Upload>();
            UsuarioIdEmpresaNavigation = new HashSet<Usuario>();
            UsuarioIdEmpresaSelecionadaNavigation = new HashSet<Usuario>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string RazaoSocial { get; set; }
        [StringLength(150)]
        public string NomeFantasia { get; set; }
        [StringLength(14)]
        [Unicode(false)]
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativa { get; set; }
        public int? IdRepresentante { get; set; }
        [Required]
        [StringLength(250)]
        public string Dominio { get; set; }        

        [ForeignKey("IdRepresentante")]
        [InverseProperty("Empresa")]
        public virtual Usuario IdRepresentanteNavigation { get; set; }    
        [InverseProperty("IdEmpresaNavigation")]
        public virtual EmpresaLogo EmpresaLogo { get; set; }        
        [InverseProperty("IdEmpresaNavigation")]
        public virtual ICollection<Download> Download { get; set; }
        [InverseProperty("IdEmpresaNavigation")]
        public virtual ICollection<Upload> Upload { get; set; }
        [InverseProperty("IdEmpresaNavigation")]
        public virtual ICollection<Usuario> UsuarioIdEmpresaNavigation { get; set; }
        [InverseProperty("IdEmpresaSelecionadaNavigation")]
        public virtual ICollection<Usuario> UsuarioIdEmpresaSelecionadaNavigation { get; set; }
    }
}