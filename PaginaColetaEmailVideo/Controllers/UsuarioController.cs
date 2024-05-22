using Microsoft.AspNetCore.Mvc;
using PaginaColetaEmailVideo.Dto;
using PaginaColetaEmailVideo.Filtros;
using PaginaColetaEmailVideo.Models;
using PaginaColetaEmailVideo.Services.UsuarioService;

namespace PaginaColetaEmailVideo.Controllers
{
    [UsuarioLogado]
    public class UsuarioController : Controller
    {

        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if(ModelState.IsValid)
            {
                var usuario = await _usuarioInterface.Cadastrar(usuarioCriacaoDto);

                if(usuario != null)
                {
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Email");
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro no momento do cadastro!";
                    return View(usuarioCriacaoDto);
                }

            }
            else{
                return View(usuarioCriacaoDto);
            }
        }

    }
}
