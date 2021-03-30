using Invest.Data.Entities;
using Invest.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Invest.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IGenericRepository<Empresas> _repositorioGenericoDeEmpresas;
        private readonly IGenericRepository<ClassificacaoSetorial> _repositorioGenericoDeClassificacaoSetorial;
        private readonly IGenericRepository<CodigoDeNegociacao> _repositorioGenericoDeCodigoDeNegociacao;
        private readonly IGenericRepository<Segmento> _repositorioGenericoDeSegmento;
        private readonly IGenericRepository<Setor> _repositorioGenericoDeSetor;
        private readonly IGenericRepository<SubSetor> _repositorioGenericoDeSubSetor;
        public EmpresasController(IGenericRepository<Empresas> RepositorioGenericoDeEmpresas,
            IGenericRepository<ClassificacaoSetorial> RepositorioGenericoDeClassificacaoSetorial,
            IGenericRepository<CodigoDeNegociacao> RepositorioGenericoDeCodigoDeNegociacao,
            IGenericRepository<Segmento> RepositorioGenericoDeSegmento,
            IGenericRepository<Setor> RepositorioGenericoDeSetor,
            IGenericRepository<SubSetor> RepositorioGenericoDeSubSetor)
        {
            this._repositorioGenericoDeClassificacaoSetorial = RepositorioGenericoDeClassificacaoSetorial;
            this._repositorioGenericoDeCodigoDeNegociacao = RepositorioGenericoDeCodigoDeNegociacao;
            this._repositorioGenericoDeEmpresas = RepositorioGenericoDeEmpresas;
            this._repositorioGenericoDeSegmento = RepositorioGenericoDeSegmento;
            this._repositorioGenericoDeSetor = RepositorioGenericoDeSetor;
            this._repositorioGenericoDeSubSetor = RepositorioGenericoDeSubSetor;
        }
        public ActionResult Index()
        {
            var csv = new List<string[]>();
            var lines = System.IO.File.ReadAllLines(@"C:/Users/thoma/OneDrive/Área de Trabalho/Invest/CVM.csv");
            List<Empresas> empresas = new List<Empresas>();
            foreach (string line in lines)
                csv.Add(line.Split(';'));
            foreach (var item in csv)
            {
                if (item[0] != "CNPJ")
                {
                    empresas.Add(new Empresas() { CNPJ = item[0], NOME_FANTASIA = item[1], SITUACAO = item[3] });
                }
            }


            var requisicaoWeb = WebRequest.CreateHttp("http://bvmf.bmfbovespa.com.br/pt-br/mercados/acoes/empresas/ExecutaAcaoConsultaInfoEmp.asp?CodCVM=25291&ViewDoc=1&AnoDoc=2021&VersaoDoc=1&NumSeqDoc=101034");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<object>(objResponse.ToString());
                var teste = post.ToString();
                teste.Split("td");
                streamDados.Close();
                resposta.Close();
            }


            return View();
        }
    }
}
