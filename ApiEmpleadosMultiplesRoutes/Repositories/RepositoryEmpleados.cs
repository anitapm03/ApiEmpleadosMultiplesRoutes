using ApiEmpleadosMultiplesRoutes.Data;
using NugetApiModels.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleadosMultiplesRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadosContext context;

        public RepositoryEmpleados(EmpleadosContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            return await this.context.Empleados.ToListAsync();
        }

        public async Task<Empleado> FindHospitalAsync(int idhospital)
        {
            return await
                this.context.Empleados
                .FirstOrDefaultAsync(x => x.IdEmpleado == idhospital);
        }

        public async Task<List<Empleado>>
            GetEmpleadosOficioAsync(string oficio)
        {
            return await this.context.Empleados
                .Where(z => z.Oficio == oficio).ToListAsync();
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> 
            GetEmpleadosSalarioAsync(int salario, int dept)
        {
            return await this.context.Empleados
                .Where(x => x.Departamento == dept
                && x.Salario >= salario).ToListAsync();
        }

    }
}
