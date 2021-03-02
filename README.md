# Criar soluções para brincar com controle de estado e fluxo 

## Regras repo

- Soluções divididas por branch
- Utilização da solução num cenário real específico deve ser composto por nome-da-branch-da-solucao/descricao-do-cenário

## Requisitos

- [ ] Posso obter histórico de alterações do objeto de todos os processos
- [ ] Posso exibir o estado do objeto de qualquer etapa do processo
- [ ] Deve permitir composição do objeto
- [ ] Deve permitir normalização de dados para cada etapa do processo caso seja necessário
- [ ] Deve persistir cada estado no banco identificando o processo E a etapa E a versão E os dados E a data de início e fim da etapa E o identificador global do processo (guid)
- [ ] Deve permitir rollback do ponto atual para um ponto específico no passado
- [ ] Posso interromper o processo quando quiser
- [ ] Pode haver cancelamento do processo todo quando houver erro em algum ponto
- [ ] Deve exibir os erros ocorridos no processo
- [ ] Deve persistir no banco os erros ocorridos no processo
- [ ] Deve permitir versionamento do processo
- [ ] Deve permitir versionamento de etapa do processo
- [ ] Posso executar ou não uma etapa do processo baseado em suas regras de execução
- [ ] Deve permitir validação de entrada de dados na etapa
- [ ] Deve permitir validação de saída de dados na etapa
- [ ] Posso utilizar etapa de um processo em outro processo praticando o reuso
- [ ] Posso compor um processo novo utilizando outros processos
- [ ] Posso consumir serviços externos para compor objeto de etapa
- [ ] Posso consumir serviços externos para validar objeto de etapa

## Regras de commit

### Legenda

- adic -> Adicionado -> recurso novo, adição
- ajst -> Ajustado -> correção de recurso existente, bugs (fix)
- rmv -> Removido -> remoção de recurso
- rft -> Refatorado -> melhoria de desempenho ou reorganização ou limpeza do código 

### Exemplo

`Ex.: adic: regra de commit`

## Relatório conclusivo da solução
