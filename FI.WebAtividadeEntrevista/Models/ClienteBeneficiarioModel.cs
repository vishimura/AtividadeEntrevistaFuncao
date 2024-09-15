using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using WebAtividadeEntrevista.Helper;

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteBeneficiarioModel
    {
        public ClienteModel Cliente { get; set; }
        public List<Beneficiario> Beneficiarios { get; set; }
        public ClienteBeneficiarioModel()
        {
            Beneficiarios = new List<Beneficiario>();
        }

    }

    public class BeneficiarioModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [Required]
        [RegularExpression(@"^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$ ou ^\d{3}\x2E\d{3}\x2E\d{3}\x2D\d{2}$", ErrorMessage = "Digite um cpf v�lido")]
        public string Cpf { get; set; }

        public long IdCliente { get; set; }

        public bool ExisteCpf(string Cpf, List<Beneficiario> Beneficiarios)
        {
            var cpfNum = StringFunctions.SoNumeroString(Cpf);
            Beneficiario BeneficiarioCpfExiste = Beneficiarios.Find(
                c => StringFunctions.SoNumeroString(c.Cpf) == cpfNum
             );

            return BeneficiarioCpfExiste != null;
        }
    }
}