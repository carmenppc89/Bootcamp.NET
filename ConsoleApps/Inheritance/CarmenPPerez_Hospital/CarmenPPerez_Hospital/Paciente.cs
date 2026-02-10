using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarmenPPerez_Hospital
{
    public class Paciente : Persona
    {
        private Medico _medicoAsignado;
        public Medico MedicoAsignado { get => _medicoAsignado; }

        public Paciente(string nombre) : base(nombre) { }
        public Paciente(string nombre, Medico medico) : base(nombre)
        {
            AssignarMedico(medico);
        }

        public void AssignarMedico(Medico medico)
        {
            // si ya tiene medico
            if (_medicoAsignado != null)
                DESAssignarMedico();

            _medicoAsignado = medico;
            medico.AñadirPaciente(this);
        }

        public void DESAssignarMedico()
        {
            _medicoAsignado.QuitarPaciente(this);
            _medicoAsignado = null;
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
    Medico:     {(MedicoAsignado != null ? MedicoAsignado.Nombre : "ninguno asignado")}";
        }
    }
}
