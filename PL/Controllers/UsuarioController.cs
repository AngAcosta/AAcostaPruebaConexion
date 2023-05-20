﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
        }

        public ActionResult Form(int? IdUsuario)
        {
            ML.Result result = new ML.Result();
            ML.Usuario usuario = new ML.Usuario();

            if (IdUsuario == null)
            {
                return View(usuario);
            }
            else
            {
                result = BL.Usuario.GetById(IdUsuario.Value);
                usuario = (ML.Usuario)result.Object;

                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.Add(usuario);

                if (result.Correct)
                {
                    return View("Modal");
                }
                else
                {
                    return View("Modal");
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);

                if (result.Correct)
                {
                    return View("Modal");
                }
                else
                {
                    return View("Modal");
                }
            }
        }

        public ActionResult Delete(int IdUsuario)
        {
            ML.Result result = BL.Usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                return View("Modal");
            }
            return View();
        }
    }
}