Desafio realizado na aula da faculdade
Consolidar os conhecimentos de programação gráfica e POO em um sistema real.
Desenvolver uma aplicação que possibilite o cadastro, edição, remoção e listagem de lançamentos financeiros.
Aplicar a arquitetura MVC para separar responsabilidades e tornar o sistema mais modular.

Descrição do Desafio
1. Interface Gráfica
Desenvolva um formulário Windows Forms com os seguintes componentes:
TextBox para inserir a descrição do lançamento financeiro.
NumericUpDown para informar o valor do lançamento.
ComboBox para selecionar o tipo de lançamento (Receita ou Despesa).
DateTimePicker para escolher a data do lançamento.
Button para adicionar ou atualizar o lançamento.
DataGridView para exibir os lançamentos cadastrados (ID, descrição, valor, tipo, data).
Botões para remover lançamentos e gerar gráficos, como o total de receitas versus despesas.

2. Modelo de Dados (Model)
Classe Lancamento com os atributos:
Id (inteiro, gerado automaticamente)
Descricao (string)
Valor (decimal)
Tipo (string: "Receita" ou "Despesa")
Data (DateTime)
Classe FinancasModel que gerencie a lista de lançamentos, com métodos para adicionar, atualizar, remover e listar os registros.
Métodos para calcular totais e gerar relatórios financeiros.

3. Controlador (Controller)
Classe LancamentoController para orquestrar as operações entre a interface e o modelo.
Responsável por:
Receber e validar os dados inseridos na interface.
Invocar métodos do modelo para manipulação dos lançamentos.
Atualizar o DataGridView e os gráficos sempre que ocorrer alguma modificação.

4. Funcionalidades
Adicionar Lançamento: Validação dos dados e cadastro do lançamento financeiro.
Listar Lançamentos: Atualização e exibição contínua da lista de lançamentos no DataGridView.
Exibir Todos
Filtrar Listagem Por Receita
Filtrar Listagem Por Despesas
