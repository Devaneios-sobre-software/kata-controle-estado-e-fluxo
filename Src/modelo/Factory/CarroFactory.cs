using System.Linq;
using modelo.Processos;
using modelo.Processos.Mapeamento;
using modelo.Processos.MotorDeCarro;
using modelo.Processos.RodaDeCarro;
using modelo.Processos.RodaDeCarro.CaixaMarcha;
using modelo.Processos.RodaDeCarro.Carroceria;
using modelo.Processos.Validacao;

namespace modelo.Factory
{
    public sealed class CarroFactory
    {
        public CarroFactory()
        {

        }

        public IDadoBoxDto Criar(IDadoBoxDto entrada)
        {
            var montaMotor = new ProcessoBuilder()
                .Adicionar(new CabecoteProcesso())
                .Adicionar(new ComandoDeValvulaProcesso())
                .Adicionar(new CilindroProcesso())
                .Adicionar(new VirabrequinProcesso())
                .Adicionar(new PistaoProcesso())
                .Adicionar(new BielaProcesso())
                .Adicionar(new CarterDeOleoMotorProcesso())
                .Adicionar(new CamaraDeCombustaoProcesso());

            var motor = new ProcessoExecucaoPilhaService(entrada)
                .RodarPilha(montaMotor)
                .ObterResultadoDeExecucao();

            var montaEixo = new ProcessoBuilder()
                .Adicionar(new EixoProcesso());

            var eixo = new ProcessoExecucaoPilhaService(motor)
               .RodarPilha(montaEixo)
               .ObterResultadoDeExecucao();


            var montaCaixaDeMarcha = new ProcessoBuilder()
                .Adicionar(new EncaixarEngrenagensProcesso())
                .Adicionar(new LubrificarProcesso());

            var caixaMarcha = new ProcessoExecucaoPilhaService(motor)
               .RodarPilha(montaCaixaDeMarcha)
               .ObterResultadoDeExecucao();


            var montaCarroceria = new ProcessoBuilder()
                .Adicionar(new InstalacaoEixoProcesso())
                .Adicionar(new PinturaProcesso())
                .Adicionar(new InstalacaoEletricaProcesso())
                .Adicionar(new InstalacaoHidraulicaProcesso())
                .Adicionar(new InstalacaoPortasProcesso())
                .Adicionar(new InstalacaoFaroisProcesso())
                .Adicionar(new InstalacaoCapoProcesso())
               ;

            var carroceria = new ProcessoExecucaoPilhaService(motor)
                .RodarPilha(montaCarroceria)
                .ObterResultadoDeExecucao();

            return carroceria;
        }
    }
}