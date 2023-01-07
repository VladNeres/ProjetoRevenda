using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRevenda.Repositorys
{
    public class EnderecoRepository
    {
        public DatabaseContext _context;
        public IMapper _mapper;

        public EnderecoRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void AtualizarEndereco(Endereco catDto)
        {
            _context.Update(catDto);
            _context.SaveChanges();
        }

        public Endereco RecuperarEnderecoPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        }

        public List<Endereco> GetEndereco()
        {
             List<Endereco> endereco =_context.Enderecos.ToList();
            return endereco;
        }

        public void DeletarEnderecoPorId(Endereco endereco)
        {
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            
        }
    }
}
