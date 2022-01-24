using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class OperatorService
    {
        public Repository _repository = new Repository();

        public Operator GetOperatorByCode(string code)
        {
            
            var operators = _repository.GetAll<Operator>();
            var selectedOperator = operators.FirstOrDefault(o => o.Code == code);
            if(selectedOperator is null)
            {
                var operatorAux = new Operator();
                operatorAux.Id = Guid.NewGuid();
                operatorAux.Code = code;
                _repository.Insert(operatorAux);
                selectedOperator = operatorAux;
            }
            return selectedOperator;
        }

        public Operator GetOperatorById(Guid id)
        {
            var selectedOperator = _repository.GetById<Operator>(id);
            return selectedOperator;
        }

        public List<Operator> GetOperators()
        {
            var operators = _repository.GetAll<Operator>();
            return operators;
        }

        public void Create(Operator insertingOperator)
        {
            _repository.Insert(insertingOperator);
        }

        public void Update(Operator updatingOperator)
        {
            _repository.Update(updatingOperator);
        }
    }
}
