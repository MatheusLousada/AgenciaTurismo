-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 17-Abr-2021 às 07:23
-- Versão do servidor: 10.4.18-MariaDB
-- versão do PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `agenciaturismo`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `pacotesturisticos`
--

CREATE TABLE `pacotesturisticos` (
  `Id` int(32) NOT NULL,
  `Nome` text DEFAULT NULL,
  `Origem` text DEFAULT NULL,
  `Destino` text DEFAULT NULL,
  `Atrativos` text DEFAULT NULL,
  `Saida` datetime DEFAULT NULL,
  `Retorno` datetime DEFAULT NULL,
  `Usuario` int(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `pacotesturisticos`
--

INSERT INTO `pacotesturisticos` (`Id`, `Nome`, `Origem`, `Destino`, `Atrativos`, `Saida`, `Retorno`, `Usuario`) VALUES
(6, 'Canadá', 'Porto Alegre', 'Ottawa', 'Clima, Paisagens, Cataratas', '2021-04-17 00:00:00', '2021-04-22 00:00:00', 6),
(7, 'Alemanha', 'Belo Horizonte', 'Berlim', 'Baviera, Berlim, Frankfurt', '2021-04-25 00:00:00', '2021-07-15 00:00:00', 2),
(8, 'Portugal', 'Brasília', 'Porto', 'Ilhas, Coimbra', '2021-04-03 00:00:00', '2021-07-06 00:00:00', 9),
(9, 'Havaí', 'São Paulo', 'Oahu', 'Praias, Ilhas, Surf', '2021-03-28 00:00:00', '2021-05-08 00:00:00', 33),
(10, 'Itália', 'Santos', 'Roma', 'Coliseu, Veneza', '2021-07-23 00:00:00', '2021-10-12 00:00:00', 15),
(11, 'Tailândia', 'Florianópolis', 'Bangkok', 'Palácios, Templos', '2021-06-09 00:00:00', '2021-09-28 00:00:00', 7);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` text DEFAULT NULL,
  `Login` text DEFAULT NULL,
  `Senha` text DEFAULT NULL,
  `DataNascimento` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `DataNascimento`) VALUES
(1, 'Matheus', 'matheus_lousada', '1609', '2021-04-12 20:50:13'),
(4, 'Patrícia Soares', 'paty123', '123', '2021-03-31 00:00:00');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  ADD PRIMARY KEY (`Id`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `pacotesturisticos`
--
ALTER TABLE `pacotesturisticos`
  MODIFY `Id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
