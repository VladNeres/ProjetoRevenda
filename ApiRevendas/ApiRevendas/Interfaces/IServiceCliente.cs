﻿using CategoriaApi.Model;
using FluentResults;
using RevendaApi.Data.Dto.ClienteDto;
using System.Collections.Generic;

namespace ApiRevenda.Interfaces
{
    public interface IServiceCliente
    {
        public ReadClienteDto AdicionarCliente(CreateClienteDto clienteDto);
        public Result AtualizarCliente(int id, UpDateClienteDto clienteDto);
        public Result ExcluiCliente(int id);
        public List<Cliente> PesquisarListaCliente();
        public ReadClienteDto GetClientePorId(int id);
    }
}
