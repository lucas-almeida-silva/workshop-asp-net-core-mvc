﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }


        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //Indica que vai ser uma ação de post
        [ValidateAntiForgeryToken]//anotação para prevenir que a aplicação sofra ataques csrf, quando alguém aproveita a sua sessão de autenticação e envia dados maliciosos
        public IActionResult Create(Seller seller) //essa operação recebe um objeto vendedor que veio na requisição, para receber este objeto e instanciar o vendedor, basta colocá-lo como parâmetro, é um recurso do EntityFramework
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));//redirecionar para o index

        }
    }
}