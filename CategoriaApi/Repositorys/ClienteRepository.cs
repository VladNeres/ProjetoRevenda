﻿using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using RevendaApi.Data.Dto.ClienteDto;
using System;
using System.Linq;

namespace ApiRevenda.Repositorys
{
    public class ClienteRepository
    {
        private DatabaseContext _context;
        public ClienteRepository( DatabaseContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente clienteDto)
        {
            _context.Clientes.Add(clienteDto);
            _context.SaveChanges();
        }

        public void ExcluirCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        } 
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public object PesquisarListaCliente()
        {
            return _context.Clientes.ToList();
        }
        public Cliente RecuperaClientePorId(int id)
        {
            Cliente clienteId= _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            return clienteId;
        }
    }
}
