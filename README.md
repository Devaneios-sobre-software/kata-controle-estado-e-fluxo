# Criar fluxos para brincar com soluções de controle de estado sem seguir padrão GoF

- Posso obter histórico de alterações do objeto de todos os processos
- Posso exibir o estado do objeto de qualquer ponto na história do processo
- Deve permitir composição do objeto
- Deve permitir normalização de dados para cada etapa do processo caso seja necessário
- Deve persistir cada estado no banco cassandra
- Deve permitir rollback do ponto atual para um ponto específico no passado
- Posso interromper o fluxo quando quiser
