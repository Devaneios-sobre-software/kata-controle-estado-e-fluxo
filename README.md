# Criar soluções para brincar com controle de estado e fluxo 

## Regras repo

- Soluções divididas por branch

## Requisitos

- [ ] Posso obter "histórico" do resultado de todos os processos dentro de um plano de execução
- [ ] Deve permitir composição do agregado (o agregado passado como entrada de um processo poderá ser alterado apenas se esse método de alteração estiver nele publicamente , de modo que somente ele possa realizar essa alteraçào, evitando assim o side-effect)
- [ ] Deve permitir normalização de dados na entrada ou saída de processo, tratando-o como um outro processo. (processo de validação X por exemplo)
- [ ] Deve persistir resultado de processo identificando-o com a versão E os dados gerados E a data de início e fim da etapa E o identificador global do plano de execução (guid) E o relatório de execução
- [ ] Deve existir um controle para registrar eventos na execução de um plano. Esse controle deve se chamar relatório de execução. Será tipo um notification pattern
- [ ] Posso interromper o plano de execução quando houver erro crítico em algum processo
- [ ] Posso exibir o relatório de execução 
- [ ] Deve persistir o relatório de execução 
- [ ] Deve permitir versionamento do processo
- [ ] Deve permitir versionamento do plano de execução
- [ ] Posso executar ou não um processo baseado em suas políticas de execução (validação de política)
- [ ] Deve permitir validação politica que será tratado como processo. (Validação de entrada ou saída de dados por exemplo)
- [ ] Posso compor um processo utilizando outros processos e/ou planos de execução (composição)
- [ ] Posso ter processsos para consumir serviços externos (para compor agregado num processo por exemplo)
- [ ] Posso reprocessar qualquer processo dentro de plano de execução 
- [ ] Não deve permitir herança entre classes , apenas implementação de interface quando necessária

## Regras de commit

### Legenda

- adic -> Adicionado -> recurso novo, adição
- ajst -> Ajustado -> correção de recurso existente, bugs (fix)
- rmv -> Removido -> remoção de recurso
- rft -> Refatorado -> melhoria de desempenho ou reorganização ou limpeza do código 

### Exemplo

`Ex.: adic: regra de commit`

## Relatório de resultados

...
