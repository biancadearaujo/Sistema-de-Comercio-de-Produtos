-- -----------------------------------------------------
-- Schema vendas
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `vendas` ;

-- -----------------------------------------------------
-- Schema vendas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `vendas` DEFAULT CHARACTER SET utf8 ;
USE `vendas` ;

-- -----------------------------------------------------
-- Table `vendas`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Usuario` (
  `id_usuario` INT NOT NULL auto_increment,
  `nome` VARCHAR(45) NOT NULL,
  `senha` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_usuario`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `vendas`.`Fornecedor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Fornecedor` (
  `id_fornecedor` INT NOT NULL auto_increment,
 `nome` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(11) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `rua` VARCHAR(45) NOT NULL,
  `numero` INT NOT NULL,
  `complemento` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `uf` VARCHAR(2) NOT NULL,
  `cep` VARCHAR(8) NOT NULL,
  
  PRIMARY KEY (`id_fornecedor`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`Produto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Produto` (
  `id_produto` INT NOT NULL auto_increment,
  `nome` VARCHAR(45) NOT NULL,
  `quantidade_estoque` INT NOT NULL,
  `preco` DOUBLE NOT NULL,
  `unidade` VARCHAR(3) NOT NULL,
  `id_fornecedor` INT NOT NULL,
  PRIMARY KEY (`id_produto`),
  INDEX `fk_fornecedor_idx` (`id_fornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_Produto_Fornecedor`
    FOREIGN KEY (`id_fornecedor`)
    REFERENCES `vendas`.`Fornecedor` (`id_fornecedor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Cliente` (
  `id_cliente` INT NOT NULL auto_increment,
 `nome` VARCHAR(45) NOT NULL,
  `telefone` VARCHAR(11) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `rua` VARCHAR(45) NOT NULL,
  `numero` INT NOT NULL,
  `complemento` VARCHAR(45) NULL,
  `bairro` VARCHAR(45) NOT NULL,
  `cidade` VARCHAR(45) NOT NULL,
  `uf` VARCHAR(2) NOT NULL,
  `cep` VARCHAR(8) NOT NULL,
  
  PRIMARY KEY (`id_cliente`))
ENGINE = InnoDB;




-- -----------------------------------------------------
-- Table `vendas`.`Venda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Venda` (
  `id_venda` INT NOT NULL auto_increment,
  `data` DATE NOT NULL,
  `id_cliente` INT NULL,
  `total_venda` DOUBLE NOT NULL,
  `situacao_venda` VARCHAR(45) NOT NULL,
  `forma_pagamento` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_venda`),
  INDEX `fk_cliente_idx` (`id_cliente` ASC) VISIBLE,
  CONSTRAINT `fk_Venda_Cliente`
    FOREIGN KEY (`id_cliente`)
    REFERENCES `vendas`.`Cliente` (`id_cliente`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`ItemVenda`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`ItemVenda` (
  `id_venda` INT NOT NULL auto_increment,
  `numero_item` INT NOT NULL,
  `id_produto` INT NULL,
  `quantidade` INT UNSIGNED NOT NULL,
  `valor_unitario` DOUBLE NOT NULL,
  `total_item` DOUBLE NOT NULL,
  PRIMARY KEY (`id_venda`, `numero_item`),
  INDEX `fk_produto_idx` (`id_produto` ASC) VISIBLE,
  CONSTRAINT `fk_ItemVenda_Venda`
    FOREIGN KEY (`id_venda`)
    REFERENCES `vendas`.`Venda` (`id_venda`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemVenda_Produto`
    FOREIGN KEY (`id_produto`)
    REFERENCES `vendas`.`Produto` (`id_produto`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`Compra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Compra` (
  `id_compra` INT NOT NULL auto_increment,
  `data` DATE NOT NULL,
  `hora` TIME NOT NULL,
  `id_fornecedor` INT NULL,
  `total_compra` DOUBLE NOT NULL,
  `situacao_compra` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id_compra`),
  INDEX `fk_fornecedor_idx` (`id_fornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_Compra_Fornecedor`
    FOREIGN KEY (`id_fornecedor`)
    REFERENCES `vendas`.`Fornecedor` (`id_fornecedor`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`ItemCompra`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`ItemCompra` (
  `id_compra` INT NOT NULL auto_increment,
  `numero_item` INT NOT NULL,
  `id_produto` INT NOT NULL,
  `quantidade` INT NOT NULL,
  `valor_unitario` DOUBLE NOT NULL,
  `total_item` DOUBLE NOT NULL,
  PRIMARY KEY (`id_compra`, `numero_item`),
  INDEX `fk_produto_idx` (`id_produto` ASC) VISIBLE,
  CONSTRAINT `fk_ItemCompra_Compra`
    FOREIGN KEY (`id_compra`)
    REFERENCES `vendas`.`Compra` (`id_compra`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemCompra_Produto`
    FOREIGN KEY (`id_produto`)
    REFERENCES `vendas`.`Produto` (`id_produto`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`ContaReceber`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`ContaReceber` (
  `id_conta_receber` INT NOT NULL auto_increment,
  `descricao` VARCHAR(45) NULL,
  `id_cliente` INT NOT NULL,
  `data_lancamento` DATE NOT NULL,
  `data_vencimento` DATE NOT NULL,
  `valor` DOUBLE NOT NULL,
  `recebido` VARCHAR(5) NOT NULL,
  `data_recebimento` DATE NULL,
  `valor_recebimento` DOUBLE NULL,
  PRIMARY KEY (`id_conta_receber`),
  INDEX `fk_cliente_idx` (`id_cliente` ASC) VISIBLE,
  CONSTRAINT `fk_ContaReceber_Cliente`
    FOREIGN KEY (`id_cliente`)
    REFERENCES `vendas`.`Cliente` (`id_cliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`ContaPagar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`ContaPagar` (
  `id_conta_pagar` INT NOT NULL auto_increment,
  `descricao` VARCHAR(45) NULL,
  `id_fornecedor` INT NOT NULL,
  `data_lancamento` DATE NOT NULL,
  `data_vencimento` DATE NOT NULL,
  `valor` DOUBLE NOT NULL,
  `pago` VARCHAR(45) NOT NULL,
  `data_pagamento` DATE NULL,
  `valor_pagamento` DOUBLE NULL,
  PRIMARY KEY (`id_conta_pagar`),
  INDEX `fk_fornecedor_idx` (`id_fornecedor` ASC) VISIBLE,
  CONSTRAINT `fk_ContaPagar_Fornecedor`
    FOREIGN KEY (`id_fornecedor`)
    REFERENCES `vendas`.`Fornecedor` (`id_fornecedor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`Caixa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`Caixa` (
  `id_caixa` INT NOT NULL auto_increment,
  `nome` VARCHAR(45) NOT NULL,
  `saldo` DOUBLE NOT NULL,
  PRIMARY KEY (`id_caixa`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `vendas`.`MovimentoCaixa`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `vendas`.`MovimentoCaixa` (
  `id_caixa` INT NOT NULL auto_increment,
  `numero_movimento` INT NOT NULL,
  `data_movimento` DATE NOT NULL,
  `hora_movimento` TIME NOT NULL,
  `descricao` VARCHAR(45) NOT NULL,
  `tipo_movimento` VARCHAR(45) NOT NULL,
  `valor` DOUBLE NOT NULL,
  PRIMARY KEY (`id_caixa`, `numero_movimento`),
  CONSTRAINT `fk_MovimentoCaixa_Caixa`
    FOREIGN KEY (`id_caixa`)
    REFERENCES `vendas`.`Caixa` (`id_caixa`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

