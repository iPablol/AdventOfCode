﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2024
{
    internal class Day2() : Problem("7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9",
        "1 3 5 6 8 9 12 9\r\n66 67 70 72 73 74 75 75\r\n18 20 22 25 28 31 35\r\n85 86 87 90 93 99\r\n5 6 5 7 10 12 15 16\r\n68 70 72 73 74 73 74 71\r\n75 76 79 76 79 79\r\n38 41 44 45 43 47\r\n76 77 79 80 83 85 84 90\r\n73 76 79 79 82 85 88\r\n86 87 87 90 93 94 97 96\r\n47 48 48 49 49\r\n29 30 31 31 35\r\n85 87 89 89 90 95\r\n33 34 38 39 40 42\r\n84 86 90 93 92\r\n20 22 25 29 29\r\n76 78 81 84 85 89 92 96\r\n47 48 52 54 57 58 59 64\r\n19 20 21 27 28\r\n49 51 58 59 61 59\r\n18 21 26 29 32 32\r\n46 48 53 54 57 58 62\r\n71 72 73 78 80 85\r\n25 23 25 28 29 32 35\r\n34 32 35 38 39 40 43 42\r\n15 14 15 18 19 19\r\n48 47 49 51 55\r\n9 8 9 12 19\r\n33 31 33 34 36 37 36 37\r\n71 68 66 68 66\r\n86 84 86 85 86 88 88\r\n30 27 28 27 28 30 32 36\r\n77 76 74 75 78 85\r\n66 63 64 65 65 67\r\n48 45 47 49 52 52 53 50\r\n28 26 26 27 30 33 33\r\n26 25 25 27 28 29 33\r\n93 91 92 92 97\r\n36 35 39 42 43 46 47\r\n18 15 18 22 25 22\r\n43 41 43 46 50 52 52\r\n28 27 30 32 33 37 41\r\n58 56 58 62 63 65 67 73\r\n3 1 3 8 9\r\n28 27 30 33 34 39 38\r\n65 64 65 68 75 75\r\n51 48 55 57 61\r\n57 54 61 64 65 71\r\n26 26 27 28 31 33 34 35\r\n37 37 40 41 43 44 47 44\r\n41 41 43 44 47 50 51 51\r\n32 32 34 36 37 40 41 45\r\n32 32 35 38 40 41 42 47\r\n79 79 80 77 78 81\r\n91 91 89 92 95 97 99 96\r\n86 86 83 85 88 88\r\n37 37 36 38 42\r\n63 63 60 61 63 66 73\r\n43 43 43 44 47\r\n54 54 57 57 58 57\r\n26 26 29 31 31 33 33\r\n21 21 24 27 27 31\r\n9 9 10 12 14 14 15 22\r\n41 41 44 48 49 52 53 54\r\n16 16 18 22 24 26 25\r\n11 11 13 17 20 20\r\n62 62 63 65 66 70 72 76\r\n74 74 76 78 82 85 91\r\n72 72 75 76 81 84\r\n12 12 14 21 24 25 26 23\r\n6 6 8 10 15 15\r\n10 10 11 12 14 20 24\r\n17 17 20 21 22 29 31 36\r\n23 27 29 32 35 38 41\r\n34 38 41 44 43\r\n37 41 44 47 49 50 52 52\r\n41 45 47 48 50 51 54 58\r\n79 83 86 89 90 91 92 99\r\n25 29 30 33 36 39 36 38\r\n90 94 97 94 96 99 96\r\n84 88 86 87 88 88\r\n48 52 55 54 58\r\n46 50 49 51 53 59\r\n22 26 26 27 29\r\n52 56 59 59 56\r\n42 46 49 49 49\r\n62 66 66 69 70 74\r\n64 68 69 72 72 73 76 83\r\n10 14 17 21 22 25 26\r\n43 47 50 54 55 52\r\n85 89 92 96 96\r\n58 62 66 68 69 72 74 78\r\n8 12 16 19 24\r\n69 73 74 80 81 82\r\n65 69 76 77 75\r\n16 20 23 28 31 32 34 34\r\n41 45 48 53 55 56 60\r\n80 84 87 92 98\r\n69 75 76 79 81 84 85 87\r\n27 34 36 37 36\r\n51 57 59 60 62 62\r\n20 27 30 33 37\r\n39 45 47 50 51 57\r\n65 72 75 73 74\r\n78 83 85 87 89 86 83\r\n50 57 60 63 62 64 65 65\r\n39 46 47 44 48\r\n36 41 44 42 43 49\r\n7 14 14 17 18 21\r\n61 66 67 67 64\r\n66 73 74 76 76 77 77\r\n47 53 56 57 60 60 64\r\n38 43 45 45 52\r\n30 36 38 41 44 48 51\r\n26 32 35 38 41 43 47 46\r\n79 85 87 88 91 95 95\r\n36 43 44 46 50 52 55 59\r\n64 69 71 74 77 81 83 88\r\n46 51 53 54 57 59 66 68\r\n64 71 78 81 83 80\r\n22 29 30 35 36 36\r\n60 66 69 74 75 79\r\n23 28 33 36 37 39 42 48\r\n10 8 7 6 3 1 3\r\n69 68 65 62 61 58 58\r\n76 74 71 68 67 63\r\n84 81 80 78 76 70\r\n67 66 63 65 62\r\n35 33 30 28 31 30 32\r\n65 62 64 63 63\r\n95 93 91 92 88\r\n72 70 73 70 65\r\n69 67 67 64 62 60 58 56\r\n69 66 66 63 65\r\n11 8 5 5 5\r\n53 52 49 46 43 43 41 37\r\n19 16 15 13 13 11 4\r\n48 45 44 41 37 36 34 33\r\n52 50 47 46 42 44\r\n32 29 26 22 22\r\n29 28 24 21 18 14\r\n64 63 59 58 56 55 48\r\n62 60 57 51 48 45 42\r\n43 40 39 34 35\r\n17 16 13 12 6 5 5\r\n85 82 75 72 71 70 66\r\n55 52 49 42 35\r\n8 11 9 7 4\r\n47 49 47 44 43 40 39 42\r\n76 78 75 73 70 67 66 66\r\n64 66 64 63 60 58 56 52\r\n88 91 89 87 81\r\n35 37 40 39 36\r\n8 11 9 11 10 11\r\n4 7 6 4 6 6\r\n40 42 39 36 34 32 35 31\r\n77 79 77 76 79 76 71\r\n92 94 91 91 90 88 86\r\n55 56 55 54 54 53 54\r\n38 41 41 40 40\r\n18 19 19 18 17 13\r\n12 13 12 10 9 9 8 3\r\n11 14 11 10 9 5 2\r\n36 38 36 32 31 32\r\n12 13 10 7 6 2 1 1\r\n81 82 80 77 73 71 70 66\r\n17 20 16 13 11 9 8 1\r\n34 35 32 27 26\r\n94 96 91 90 89 90\r\n52 54 47 44 42 41 38 38\r\n75 78 77 71 70 66\r\n82 84 79 78 76 73 70 63\r\n57 57 54 53 50 49\r\n22 22 21 19 21\r\n81 81 80 77 76 75 74 74\r\n65 65 64 62 60 57 53\r\n39 39 37 34 28\r\n18 18 21 18 16 14\r\n10 10 7 9 12\r\n47 47 44 46 45 44 44\r\n69 69 71 69 66 63 62 58\r\n84 84 81 83 81 75\r\n73 73 71 71 68 65 62 59\r\n47 47 47 44 41 42\r\n86 86 84 81 80 78 78 78\r\n83 83 83 81 77\r\n36 36 33 33 32 27\r\n65 65 62 58 56\r\n77 77 76 73 70 66 63 64\r\n61 61 60 57 53 53\r\n22 22 19 15 11\r\n52 52 49 45 43 38\r\n71 71 70 67 65 60 58\r\n28 28 26 23 21 16 13 16\r\n89 89 86 80 77 75 72 72\r\n81 81 80 79 74 70\r\n84 84 83 80 79 72 66\r\n92 88 87 84 83 81 80 79\r\n83 79 76 74 73 74\r\n77 73 70 68 66 66\r\n34 30 29 26 23 21 18 14\r\n34 30 28 26 25 20\r\n53 49 47 45 43 44 42\r\n65 61 62 61 64\r\n95 91 90 91 91\r\n95 91 90 93 91 87\r\n95 91 89 86 84 83 86 80\r\n26 22 22 20 17 14 11\r\n30 26 24 21 19 19 16 19\r\n37 33 30 27 27 27\r\n20 16 14 14 10\r\n76 72 72 69 64\r\n70 66 65 61 59 57 55\r\n59 55 51 48 51\r\n84 80 76 73 73\r\n81 77 76 72 68\r\n95 91 87 86 80\r\n57 53 52 51 50 44 41 39\r\n29 25 19 16 15 17\r\n41 37 32 29 29\r\n63 59 58 56 49 47 46 42\r\n23 19 12 11 4\r\n35 29 26 24 23 22\r\n64 59 56 53 52 49 51\r\n52 47 44 43 41 41\r\n25 18 16 15 12 10 6\r\n25 19 17 15 13 12 9 2\r\n76 71 73 70 68 67\r\n58 51 50 47 50 51\r\n70 65 62 59 58 57 58 58\r\n19 12 9 6 5 7 3\r\n85 78 79 78 77 76 71\r\n85 78 78 75 74 71 68 65\r\n97 92 91 90 90 88 85 86\r\n62 56 53 51 51 51\r\n80 75 72 72 69 66 62\r\n89 83 83 80 79 72\r\n58 51 47 46 43 40\r\n95 90 88 84 86\r\n78 73 70 66 66\r\n60 53 49 46 45 41\r\n55 48 47 43 38\r\n21 15 14 11 9 4 2\r\n60 54 51 46 47\r\n50 44 42 35 32 30 30\r\n27 21 19 16 10 6\r\n53 47 41 39 38 37 32\r\n54 56 59 61 62 59\r\n3 4 7 9 12 13 16 16\r\n17 19 21 24 27 31\r\n23 26 27 28 35\r\n18 21 22 24 21 24 25 26\r\n53 55 53 55 54\r\n14 17 19 20 17 18 18\r\n78 81 82 83 81 84 87 91\r\n65 66 68 66 68 75\r\n32 34 34 37 39\r\n40 42 43 46 46 47 44\r\n58 59 61 61 61\r\n54 55 57 57 61\r\n24 25 25 27 30 32 35 41\r\n70 71 75 77 80 83 85 87\r\n79 82 84 85 88 91 95 93\r\n82 83 85 88 92 94 95 95\r\n35 37 41 43 46 50\r\n60 61 64 67 71 77\r\n4 7 10 17 18 19\r\n28 31 37 38 37\r\n73 74 76 82 83 83\r\n54 57 59 62 69 72 73 77\r\n43 44 46 53 56 61\r\n44 41 42 44 46 47 48 51\r\n83 81 82 85 87 89 86\r\n50 49 51 54 56 58 58\r\n41 38 39 42 45 48 49 53\r\n10 8 11 14 19\r\n74 73 72 74 77 80\r\n27 25 26 27 24 21\r\n15 12 15 12 12\r\n68 66 68 66 70\r\n44 43 42 44 45 50\r\n85 84 85 88 88 91 93\r\n19 16 18 18 16\r\n50 49 49 50 53 53\r\n69 66 69 72 75 78 78 82\r\n31 30 32 33 33 36 41\r\n74 72 73 76 80 82 83\r\n82 79 82 85 86 90 87\r\n33 31 34 35 39 40 40\r\n45 42 44 46 48 52 55 59\r\n45 44 48 51 54 60\r\n46 44 49 52 54\r\n34 31 37 38 40 41 39\r\n78 77 78 85 87 88 89 89\r\n30 29 32 37 41\r\n51 50 51 54 57 63 70\r\n57 57 58 61 64 66 69 72\r\n35 35 37 38 39 42 43 41\r\n33 33 36 37 39 41 41\r\n62 62 65 66 70\r\n68 68 71 74 76 79 81 87\r\n6 6 7 9 12 13 10 12\r\n82 82 79 82 81\r\n13 13 15 13 13\r\n13 13 15 17 15 17 21\r\n47 47 50 47 50 52 57\r\n60 60 60 62 63\r\n61 61 62 62 64 66 67 64\r\n50 50 51 51 51\r\n59 59 59 61 64 68\r\n24 24 24 26 29 36\r\n72 72 76 79 81 82\r\n52 52 56 58 55\r\n32 32 33 37 38 38\r\n81 81 84 87 91 95\r\n47 47 51 53 60\r\n39 39 42 44 47 52 55 56\r\n43 43 49 50 53 55 52\r\n78 78 81 84 87 93 93\r\n46 46 47 50 56 57 60 64\r\n41 41 44 50 53 58\r\n53 57 59 62 63 66 69\r\n83 87 90 92 95 98 99 96\r\n49 53 55 57 59 61 61\r\n63 67 68 71 75\r\n77 81 82 85 87 89 95\r\n34 38 40 42 41 42 45 46\r\n8 12 14 16 17 19 18 16\r\n48 52 50 53 54 56 56\r\n4 8 6 8 12\r\n42 46 49 50 49 51 56\r\n39 43 46 47 47 48\r\n77 81 83 83 82\r\n55 59 60 62 62 65 67 67\r\n36 40 42 42 43 44 46 50\r\n66 70 73 76 79 79 82 88\r\n35 39 40 44 45 48 49 52\r\n72 76 77 81 79\r\n37 41 45 48 48\r\n36 40 43 47 51\r\n71 75 77 81 86\r\n18 22 29 30 31 33\r\n33 37 40 43 49 50 47\r\n25 29 32 34 41 41\r\n60 64 67 73 77\r\n36 40 42 47 50 53 54 60\r\n52 57 59 62 63 64\r\n10 17 20 23 20\r\n26 32 35 38 40 43 44 44\r\n78 83 85 88 90 94\r\n47 52 54 55 57 63\r\n74 79 82 85 82 85\r\n86 92 93 95 92 90\r\n42 47 48 50 53 50 50\r\n62 68 71 70 74\r\n71 78 81 80 82 83 84 90\r\n39 44 44 46 47 49 50\r\n31 36 38 38 37\r\n23 30 32 32 34 37 37\r\n19 26 29 30 30 34\r\n76 83 83 85 88 89 96\r\n58 65 67 70 71 75 77 79\r\n76 83 85 88 92 95 96 94\r\n53 60 64 66 68 68\r\n35 41 43 47 48 52\r\n50 57 61 62 64 70\r\n32 39 40 41 44 50 51\r\n72 77 84 85 87 88 86\r\n25 32 38 39 41 42 45 45\r\n15 21 24 26 33 37\r\n35 41 46 48 49 50 55\r\n61 58 57 54 56\r\n28 26 23 22 19 16 13 13\r\n54 51 49 46 42\r\n41 38 37 36 29\r\n91 89 87 84 83 84 81\r\n92 91 90 91 90 89 90\r\n87 86 88 87 87\r\n34 31 29 30 29 26 22\r\n47 44 43 40 38 36 37 32\r\n69 66 63 60 58 58 56\r\n10 7 6 4 4 2 3\r\n79 76 76 73 73\r\n60 59 59 56 54 51 47\r\n33 31 28 28 23\r\n29 27 26 23 22 18 16 15\r\n60 58 54 52 51 48 49\r\n43 41 37 35 33 31 31\r\n41 40 38 34 33 30 26\r\n89 88 85 81 76\r\n34 31 26 25 24 22 19 18\r\n92 89 84 82 79 77 80\r\n26 23 21 20 17 14 8 8\r\n53 51 50 47 41 37\r\n24 23 20 14 13 8\r\n29 31 28 26 24\r\n53 54 53 52 50 47 46 47\r\n76 78 75 74 72 69 66 66\r\n69 71 69 66 64 62 58\r\n58 61 59 58 56 50\r\n54 57 54 52 50 52 51\r\n38 39 41 38 36 37\r\n12 14 11 9 6 4 5 5\r\n35 37 36 34 35 33 32 28\r\n10 11 9 12 11 10 8 3\r\n23 25 23 23 20 17 16\r\n75 76 76 74 72 69 70\r\n58 60 57 54 54 52 52\r\n6 9 6 6 2\r\n40 43 43 41 39 33\r\n75 76 72 69 68 67\r\n40 41 40 36 39\r\n83 85 84 81 77 74 74\r\n26 28 24 21 19 15\r\n27 30 26 24 22 21 19 13\r\n50 53 52 51 45 42\r\n50 52 49 43 41 42\r\n23 24 23 20 19 12 11 11\r\n52 54 52 47 45 42 38\r\n70 71 64 61 54\r\n65 65 62 61 58 55\r\n14 14 11 8 5 4 7\r\n52 52 51 48 46 46\r\n99 99 98 97 94 90\r\n54 54 53 52 46\r\n48 48 47 45 47 45\r\n64 64 61 64 67\r\n23 23 22 21 23 22 22\r\n75 75 74 76 73 70 66\r\n25 25 26 25 23 21 19 13\r\n74 74 72 72 71\r\n75 75 73 70 70 72\r\n94 94 92 89 89 88 88\r\n27 27 24 24 22 20 17 13\r\n59 59 59 58 56 51\r\n44 44 41 37 36 33\r\n14 14 12 9 8 4 5\r\n74 74 71 67 67\r\n25 25 21 18 15 13 12 8\r\n60 60 56 53 47\r\n39 39 37 34 33 30 24 21\r\n60 60 59 58 51 54\r\n24 24 21 18 11 8 6 6\r\n62 62 59 52 50 48 45 41\r\n42 42 40 39 33 32 26\r\n14 10 8 7 5 2\r\n69 65 63 62 61 60 59 61\r\n55 51 48 46 43 42 42\r\n38 34 31 29 28 25 21\r\n29 25 22 21 19 18 17 11\r\n55 51 50 51 48 47 45 42\r\n87 83 82 85 84 85\r\n42 38 35 32 33 31 31\r\n29 25 23 20 18 15 16 12\r\n87 83 84 81 78 72\r\n25 21 19 17 17 16 14 13\r\n68 64 62 59 57 57 58\r\n86 82 80 80 80\r\n94 90 90 87 84 81 77\r\n64 60 59 58 56 56 54 49\r\n89 85 81 78 76 73\r\n63 59 55 53 50 53\r\n68 64 61 60 57 53 51 51\r\n57 53 51 49 45 42 41 37\r\n57 53 51 48 44 41 36\r\n77 73 70 64 63\r\n37 33 31 28 25 19 17 19\r\n34 30 27 24 19 19\r\n67 63 61 56 55 52 48\r\n90 86 79 77 71\r\n45 40 39 38 36 35 32 29\r\n21 15 12 11 12\r\n27 21 19 18 17 16 16\r\n94 88 85 84 82 81 80 76\r\n93 87 84 83 80 73\r\n59 54 53 56 55\r\n86 79 81 79 77 75 76\r\n80 73 74 71 71\r\n14 7 5 3 5 1\r\n95 89 91 88 83\r\n85 79 79 76 73\r\n97 92 89 87 87 85 88\r\n50 44 44 41 39 38 35 35\r\n37 32 32 29 27 26 22\r\n87 82 82 79 76 74 68\r\n43 37 35 34 30 29\r\n35 30 27 23 22 19 16 17\r\n74 67 65 61 60 59 57 57\r\n82 76 73 69 67 66 62\r\n57 52 49 45 42 41 36\r\n36 29 22 20 17\r\n45 40 37 31 34\r\n37 31 29 22 20 20\r\n64 59 52 51 48 44\r\n23 17 11 10 8 1\r\n45 50 52 53 56 60 67\r\n5 9 7 10 9\r\n34 40 44 46 48 49\r\n34 34 36 42 44 45 49\r\n67 62 63 60 59 53\r\n43 43 40 36 33 32 32\r\n90 86 84 80 77 74 71 64\r\n74 75 77 79 84 86 89\r\n37 35 37 40 42 43 47\r\n91 84 82 79 76 75 74 68\r\n31 26 24 22 21 21 21\r\n24 22 21 20 16 16\r\n18 14 12 11 8 4 4\r\n70 77 78 81 83 85 87 93\r\n36 30 26 23 23\r\n39 39 37 34 34 31\r\n42 38 39 36 35 34 30\r\n13 14 16 17 14 13\r\n18 18 16 14 10 8 7 2\r\n71 74 75 78 79 82 81\r\n56 55 59 60 62 65\r\n32 28 26 24 24 25\r\n8 12 14 18 20 22 25 25\r\n81 85 86 84 91\r\n61 62 65 66 71 75\r\n27 21 22 19 16 13 11 11\r\n1 5 6 7 11 14\r\n87 86 83 81 74\r\n69 76 76 77 79\r\n19 17 21 24 25 28 28\r\n36 30 29 25 23 26\r\n67 67 69 74 76\r\n63 67 70 70 74\r\n69 69 67 64 61 59 61\r\n80 78 75 72 69 67 63\r\n43 43 44 45 48 48 51 51\r\n60 64 67 68 71 72 73 72\r\n26 33 34 36 38 45 44\r\n99 99 97 94 90 87 85 88\r\n70 77 79 80 84\r\n38 38 41 42 40\r\n49 49 50 51 53 57 60 59\r\n82 82 81 81 80 79 82\r\n15 15 16 18 20\r\n82 80 77 80 84\r\n14 18 18 20 21 18\r\n25 25 22 19 14\r\n92 91 89 90 87 87\r\n82 78 77 75 77 77\r\n32 27 25 20 17 15\r\n91 84 78 77 74 73 76\r\n50 48 51 51 53 55\r\n57 53 50 49 48 46\r\n84 80 78 75 71 68 64\r\n84 78 77 74 71 69 66 66\r\n26 27 24 23 22 18 14\r\n80 78 77 76 69 72\r\n90 86 83 81 80 80 79 79\r\n56 49 48 50 49 46\r\n36 40 41 44 49 51 54 60\r\n77 79 80 83 84 87 91 98\r\n81 80 83 88 92\r\n38 40 39 38 35 38\r\n20 17 16 14 11 10 6 2\r\n68 69 73 76 79 83\r\n72 68 66 64 64 62 60\r\n56 63 63 65 66 67 69 69\r\n7 11 13 13 15 16 16\r\n19 25 28 30 33 40 42\r\n86 86 84 77 78\r\n26 26 23 21 19 20 19 14\r\n23 23 24 26 27 29 33 37\r\n25 28 25 22 20 17 13\r\n95 95 93 90 88 83 81 75\r\n53 53 55 60 63 65 68 67\r\n76 77 76 77 79 82 83 85\r\n51 51 50 49 48\r\n58 58 54 53 52 50 48 45\r\n26 28 26 23 23 22 18\r\n16 16 20 23 26 29 31\r\n21 25 27 29 35 39\r\n71 70 76 78 81 83 84 81\r\n97 91 88 88 85 82 81 83\r\n76 76 78 81 82 84 87 93\r\n75 72 67 64 62\r\n48 45 46 49 52\r\n29 25 22 18 16 14\r\n68 75 75 77 79 80 87\r\n69 67 64 63 56 56\r\n74 80 81 81 82 84 86 83\r\n89 90 90 93 97\r\n17 17 16 19 18 17 14\r\n12 8 7 4 2 5\r\n93 89 87 81 78\r\n88 88 91 91 93 91\r\n50 46 39 38 40\r\n87 90 89 85 84 83 83\r\n26 24 28 31 33 34 32\r\n22 18 17 16 15 15\r\n66 65 69 70 71 73 80\r\n82 83 84 81 81\r\n97 97 98 96 93 90 91\r\n67 67 69 67 70 73 76 83\r\n9 9 13 16 16\r\n79 73 71 68 64 61 57\r\n17 17 19 21 23 23 28\r\n60 63 60 59 58 55 53 53\r\n28 35 36 37 40 43 46 43\r\n57 52 51 48 46 48\r\n83 82 84 82 84 84\r\n24 23 23 20 19 19\r\n38 38 36 33 26 23 23\r\n26 31 34 37 41 43 47\r\n31 34 32 31 28 21 19 22\r\n68 72 74 74 75\r\n51 52 50 48 46 39 35\r\n91 94 92 90 86 83 81\r\n37 33 32 28 29\r\n36 36 29 26 22\r\n52 53 55 52 50 44\r\n19 26 28 29 32 35 37 39\r\n79 81 81 82 88\r\n47 47 49 51 54 57 59 59\r\n55 55 52 49 45\r\n84 80 82 81 79 78 76 74\r\n35 28 25 25 22 19 12\r\n76 82 79 80 80\r\n90 90 87 87 85 84 83 78\r\n77 84 86 88 88 92\r\n17 17 16 15 15\r\n34 37 36 33 32 33 31 27\r\n73 70 73 76 82\r\n62 68 69 72 78 79 79\r\n42 41 39 38 32 28\r\n69 66 69 68 64\r\n47 51 48 50 51 54 58\r\n53 57 60 63 64 65 71\r\n43 43 43 42 41 40 37 33\r\n69 66 64 67 74\r\n67 71 72 73 75\r\n13 11 12 15 16 19 19\r\n61 64 59 58 55 52 49 44\r\n57 56 55 52 50 47 48\r\n24 28 30 33 38 39 38\r\n78 75 72 70 70 68 71\r\n57 59 61 64 67 70 73\r\n13 16 19 21 22 25\r\n18 16 15 12 9\r\n17 18 20 23 24 26\r\n63 66 68 69 70 72 75\r\n36 38 40 43 44\r\n37 40 42 43 44 45 48\r\n44 42 39 37 35 34\r\n11 8 7 5 2\r\n52 54 55 57 58\r\n16 17 18 20 23 25 26\r\n87 86 83 80 77 74 73\r\n16 19 22 24 26 29 31\r\n29 31 33 36 37 39\r\n46 43 42 40 37 34 33 32\r\n84 87 90 91 93 95\r\n49 51 54 55 58 60\r\n63 61 59 58 56 53 50\r\n9 11 12 13 16 18 21 22\r\n61 60 59 58 56 55\r\n73 74 76 79 82\r\n88 90 93 95 96 99\r\n56 58 61 64 67 70\r\n82 79 78 75 72 70 69\r\n2 3 4 5 6 8\r\n32 31 28 27 24 23 22\r\n65 64 61 58 57 55\r\n57 55 52 49 46 45 43 40\r\n57 56 53 51 49 47 45\r\n2 4 5 7 8 10 11\r\n71 69 67 65 64 61 59\r\n46 48 49 51 53 55\r\n74 73 70 68 65 62\r\n62 64 65 68 71\r\n37 35 32 31 28 25 23 20\r\n58 57 54 51 48 45 42 40\r\n66 68 69 71 74\r\n4 7 9 12 14 17 19 22\r\n42 45 48 51 52 54\r\n50 52 53 56 57 58\r\n52 51 50 49 47 46 45 42\r\n53 51 49 48 46 43 40\r\n91 90 87 84 83 80 77\r\n87 84 82 79 78\r\n17 18 19 22 25 27 29 32\r\n94 91 88 87 86 84\r\n90 91 92 93 95 98\r\n4 6 9 11 13\r\n79 81 84 87 89 92 94 96\r\n42 40 37 36 34 32 29 28\r\n70 71 72 74 76\r\n22 25 28 30 33 36 38 41\r\n52 54 57 60 62 63\r\n72 71 69 66 63\r\n18 15 13 11 8 6 3 1\r\n31 28 26 23 21 19 18 17\r\n52 54 56 59 60 63 65\r\n5 7 8 9 10 12 14 17\r\n93 92 89 88 85\r\n75 73 70 69 68 67 64\r\n18 19 21 22 25\r\n31 34 36 39 41 44 46\r\n97 96 94 92 90 87 84\r\n28 26 23 21 18\r\n21 18 15 14 13 11\r\n13 16 17 19 20\r\n49 46 43 40 38 35\r\n72 69 67 65 63 62 59 56\r\n60 57 54 52 50 49 46\r\n37 40 41 42 43 46 47\r\n59 61 64 65 67\r\n33 31 28 25 22 19 18 17\r\n2 3 4 7 8 10 12\r\n82 80 79 76 74 71 69 68\r\n45 42 39 38 37 34 31 30\r\n40 41 43 44 47 50\r\n40 41 42 44 45\r\n75 78 80 81 84 85\r\n32 34 35 37 39 40 41 44\r\n51 49 47 44 43 42 40 37\r\n35 38 41 42 45 47 48 51\r\n33 34 35 37 38 40 42 43\r\n41 38 35 33 31 28 25 22\r\n64 67 69 70 71 73 74\r\n62 63 65 67 68 70 73\r\n92 89 88 85 82\r\n18 15 12 9 8 5 3\r\n48 50 52 55 56 57\r\n56 54 52 50 47 44 43 41\r\n82 83 85 88 89 90\r\n68 70 72 74 77 78\r\n28 26 24 22 21 19 17 15\r\n86 87 89 90 93 94 95\r\n48 47 46 43 40 38 36 34\r\n42 39 37 35 33 31 29 26\r\n75 78 81 84 86 88 91\r\n97 96 94 93 90\r\n32 33 36 37 38\r\n31 28 27 24 21 18 15 14\r\n90 91 93 96 98 99\r\n72 75 76 79 81\r\n26 29 31 33 34 35 36 38\r\n43 42 39 38 37\r\n23 20 17 15 14\r\n82 83 86 89 92 95\r\n14 12 11 9 6\r\n70 71 72 73 74 77\r\n74 77 80 81 82 83 86 89\r\n59 61 63 65 68 71 72\r\n69 70 72 75 78 79 81\r\n51 54 56 59 62 64 65 68\r\n83 85 87 88 89\r\n83 84 87 90 91 94 95\r\n59 57 54 53 50\r\n16 14 12 9 6 3\r\n72 69 67 64 62 61 58 57\r\n99 96 95 94 91 89 86 83\r\n45 42 40 39 36\r\n65 66 67 70 73 74 76\r\n39 42 45 48 49 52\r\n64 61 60 57 55 54 51 50\r\n42 39 36 34 31 30\r\n28 31 32 33 34 36 39 40\r\n38 40 43 45 46 47 50\r\n95 94 91 89 87\r\n38 41 43 45 46 48 51 54\r\n49 48 45 44 43 40 39 37\r\n5 8 10 12 15 18 19 22\r\n34 35 37 39 41 42\r\n65 66 67 68 71\r\n42 39 36 34 33 32\r\n81 78 77 75 72 69\r\n60 59 58 55 53 51\r\n79 80 82 84 85 88 91\r\n79 76 73 70 67 64 62\r\n99 96 95 92 91 88 87\r\n15 14 11 9 7 6\r\n11 9 8 6 3\r\n38 41 43 44 46 48\r\n30 31 32 34 36 37 38\r\n80 83 84 87 89\r\n39 37 36 34 33\r\n38 35 32 30 28 26 25\r\n42 40 38 36 33\r\n54 56 59 61 63\r\n8 11 13 15 16 19 22\r\n75 77 80 82 83 86\r\n17 20 23 24 27 28 30 33\r\n76 77 79 80 82 84\r\n33 36 39 42 43 46 49 50\r\n16 18 20 22 25 28\r\n44 46 49 51 53\r\n39 41 44 46 47\r\n75 76 77 78 80 83 85\r\n8 11 12 14 17 20 22 23\r\n64 63 60 58 57 54 53 51\r\n59 61 63 64 65 66 67 68\r\n43 41 38 35 32 29 26 23\r\n79 78 76 74 72 70 67\r\n35 37 40 43 45 46\r\n4 5 6 8 10 12\r\n34 32 29 28 25 23 21\r\n60 62 64 67 70 71\r\n40 38 37 35 33 32 30\r\n67 70 73 75 78 80 83 84\r\n34 35 38 40 42\r\n26 28 29 30 33\r\n55 53 50 48 47 46 43 41\r\n57 54 52 50 48 45 42 39\r\n57 59 62 65 67\r\n25 27 28 29 31\r\n4 5 6 7 10 12 15\r\n59 62 65 67 68 70\r\n33 30 28 27 26 24\r\n30 28 27 26 23\r\n29 32 34 35 36\r\n73 70 69 67 64 61\r\n59 60 61 63 66 67 70\r\n63 61 58 57 54\r\n48 49 52 53 55\r\n54 53 50 49 48 47 46\r\n26 23 21 19 17\r\n29 28 26 25 23\r\n25 23 21 20 18 15 13 10\r\n76 74 72 69 66\r\n98 95 92 89 86 84 81 79\r\n90 87 86 84 82 79 76\r\n48 51 54 55 57 58 60 61\r\n93 92 91 89 86 84 83\r\n16 14 13 10 7\r\n44 41 39 38 37\r\n85 82 79 77 75 74 73\r\n14 16 19 21 23\r\n61 58 57 56 54 51 48 47\r\n19 21 22 25 26 27 28 29\r\n74 72 69 68 66 63 61 60\r\n56 58 60 62 64 65\r\n56 55 53 51 49 48 47 45\r\n78 80 81 84 85 86\r\n28 26 25 22 20 17 16\r\n47 49 52 53 55 58\r\n90 91 93 94 95\r\n9 12 15 16 18 21 22 25\r\n57 55 54 53 50 48 47\r\n77 79 81 83 85 87 90\r\n42 39 37 34 33\r\n87 84 83 80 77\r\n21 19 17 16 15 12\r\n58 61 63 65 68 71 72\r\n46 49 50 51 54 56 57\r\n61 58 57 54 51 48\r\n18 21 23 26 29 31\r\n80 77 74 73 71\r\n85 83 82 80 79 78 75\r\n94 93 90 87 85 83 81 80\r\n50 48 47 46 45 44 43\r\n32 31 29 28 26 23 21\r\n90 89 88 87 85\r\n63 61 60 58 56 55 54\r\n84 81 80 77 75 74\r\n86 83 82 80 79 76 75 74\r\n53 55 58 60 62 65 66\r\n84 85 86 89 90 93\r\n18 16 13 12 11\r\n13 15 16 18 20 23 25 26\r\n7 10 11 13 14\r\n81 80 77 76 74 73 71\r\n9 8 7 4 3\r\n61 63 65 67 68 70 72\r\n5 6 8 11 12 14 16\r\n54 57 59 60 62 64 65\r\n25 28 31 32 33 36 38 40\r\n82 79 77 75 72 70 67 66\r\n84 81 79 77 76\r\n6 8 11 14 17 18 21 22\r\n12 15 17 20 21 24\r\n81 84 86 87 88 91\r\n43 45 46 48 50 51 52 54\r\n57 56 53 51 50 49 47 46\r\n65 64 63 61 59 58 56 54\r\n40 37 35 32 30 29 27\r\n82 79 77 76 74 71\r\n45 42 41 39 36 34 33\r\n20 23 25 27 28\r\n42 43 46 48 49\r\n42 45 47 49 50 53 56\r\n66 65 64 62 59 57 54\r\n49 48 46 44 41 39 38\r\n38 35 34 32 31 29 28\r\n22 23 26 27 29\r\n67 65 63 60 57 54\r\n20 22 25 27 28 30 33 36\r\n20 23 24 25 26\r\n69 71 72 73 74 76 79 81\r\n77 74 73 72 69\r\n3 5 8 10 11 12 13 14\r\n47 46 43 41 38\r\n10 11 12 14 15 17\r\n18 17 15 12 11 8 5\r\n35 37 40 41 43 44 45\r\n19 20 22 24 26 27 28\r\n70 69 67 64 61 59 57 56\r\n83 82 80 78 75 73 72 71\r\n51 48 47 44 42 41 40\r\n66 68 70 73 74\r\n93 91 90 88 85\r\n11 9 8 7 6\r\n40 37 35 33 32 31 28\r\n25 27 29 32 35\r\n35 36 38 39 41\r\n40 42 45 47 50 51 54\r\n49 52 54 56 57 60\r\n49 52 53 56 58 61 63 66\r\n64 62 59 57 56\r\n63 64 65 66 67 68\r\n70 72 73 75 78\r\n82 79 78 75 73\r\n67 66 65 63 61 60 58 55\r\n4 5 7 9 11 13\r\n71 69 67 65 63 60 57\r\n90 87 84 83 82 80 77 74\r\n31 28 25 23 21 19 17\r\n48 51 52 55 57 59 62\r\n36 34 31 30 27 25\r\n26 29 31 32 33 36\r\n44 43 40 38 37\r\n62 65 68 70 73 75\r\n61 62 64 65 68 69 72\r\n57 60 63 66 68 71 73\r\n35 37 39 40 42 43 45\r\n93 91 90 87 85\r\n24 23 21 20 19 17 15 13\r\n82 83 84 85 88\r\n30 31 32 35 37\r\n32 31 30 29 28 26 23 21\r\n57 55 53 52 49\r\n62 65 66 67 68 70\r\n64 65 68 69 70 73\r\n56 57 60 63 66 67 68 70\r\n12 14 17 19 22 24 25 27\r\n38 35 32 30 28 25 22 20\r\n73 75 76 77 79 82 83\r\n31 29 26 23 20\r\n25 26 27 30 33 34\r\n18 17 14 11 8 6\r\n25 23 22 20 17\r\n55 56 58 59 62 64 66\r\n79 80 82 85 88 89 91 92\r\n68 67 65 62 60\r\n84 87 88 89 92 93 96\r\n30 32 33 35 38 41 44\r\n86 85 82 81 79 76 75\r\n48 47 44 42 40 38\r\n72 71 69 66 63 62\r\n46 45 43 41 39 37\r\n44 42 41 40 39 38 36 33\r\n23 22 20 19 18\r\n29 30 32 33 36 38\r\n35 34 31 28 27 25 23 21\r\n54 52 50 47 45 44 43\r\n96 93 90 89 87\r\n76 77 78 81 84 86\r\n13 15 16 19 22\r\n58 60 61 63 64 66 67\r\n78 77 76 74 73 71\r\n35 38 41 44 47 49\r\n73 74 76 77 78\r\n28 26 24 23 22 21\r\n49 51 52 55 56\r\n88 91 92 95 96 99\r\n85 88 90 93 94\r\n73 76 78 80 81 83 84\r\n38 35 33 32 31 29\r\n32 29 26 23 22 20 18 16\r\n70 69 68 65 62 59 57 54\r\n80 79 76 73 70\r\n12 10 9 7 6\r\n75 72 71 69 67\r\n64 61 59 58 57 56\r\n88 90 92 95 96\r\n58 60 63 64 66\r\n99 96 95 92 91 90 89 87\r\n16 17 19 22 24 25 28\r\n77 79 81 84 85 86\r\n28 26 23 21 19 18\r\n82 81 80 79 76 74 73 70\r\n76 75 74 73 71 70 69 68\r\n94 92 91 88 85\r\n11 12 13 14 17 18 20\r\n74 73 71 69 67 65 62 61\r\n25 26 27 28 30 32 35\r\n61 64 67 68 70 73\r\n58 56 55 54 51 50\r\n69 66 65 64 61 59\r\n47 50 53 55 56\r\n26 25 22 19 16 14 12 11\r\n51 52 54 57 60 61\r\n60 59 56 55 54 52 51\r\n46 47 50 53 54 57 59 61")
    {
        private List<List<int>> reports = [];
        protected override void Solve()
        {
            Splitlines();
            foreach (string report in lines)
            {
                List<int> levels = new List<int>();
                reports.Add(levels);

                foreach (string level in report.Split(' '))
                {
                    levels.Add(int.Parse(level));
                }
            }
            foreach (List<int> levels in reports)
            {
                bool safe = CheckSafety(levels, -1);
                if (part2)
                {
                    for (int i = 0; i < levels.Count; i++)
                    {
                        if (safe) break;
                        safe = CheckSafety(levels, i);
                    }
                }
                if (safe)
                {
                    result++;
                }
            }
        }

        private bool CheckSafety(List<int> original, int skip)
        {
            List<int> levels = original.Copy();
            if (skip != -1)
                levels.RemoveAt(skip);
            bool ascending = levels.First() < levels.Last();
            bool descending = levels.First() > levels.Last();
            if (!ascending && !descending)
            {
                return false;
            }
            for (int i = 1; i < levels.Count; i++)
            {
                int previous = levels[i - 1];
                int current = levels[i];
                if (ascending && current < previous)
                {
                    return false;
                }
                if (descending && current > previous)
                {
                    return false;
                }
                int difference = Math.Abs(current - previous);
                if (difference > 3 || difference == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
