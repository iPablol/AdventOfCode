﻿

namespace AdventOfCode._2024
{
    internal class Day7() : Problem("190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20",
        "335808: 737 55 53 8\r\n249329: 3 4 994 5 92 1 227 79 4\r\n450540: 23 25 99 4 2 248 90\r\n1011357: 398 657 35 1 927\r\n6568206: 3 3 2 4 3 2 984 3 9 8 89 6\r\n116675782: 1 15 695 976 4 7 60 23\r\n241573986: 587 14 34 721 38 6\r\n60775312: 7 626 1 5 3 1 710 9 7 9 6\r\n276737138893: 3 4 4 47 9 809 1 3 47 4 9\r\n9360128: 1 7 174 4 3 5 8 8 2 6 6 80\r\n35286: 4 30 42 7 6\r\n143022: 61 38 50 8 6 2 5 9 8 6\r\n1812: 1 7 7 305 5 3 1 3\r\n159720945922: 66 55 4 6 945 9 22\r\n708627: 4 1 7 1 9 1 89 8 24 777 3\r\n29273704: 3 489 81 9 7 47 8 75 1 4\r\n54286922: 2 81 9 42 5 6 458 6 5 6 2\r\n3732: 565 57 6\r\n8295338: 30 7 627 63 128\r\n1943922: 2 4 8 22 1 5 4 9 997 5 8 2\r\n84731: 1 168 28 5 590\r\n145418: 81 4 32 906 83\r\n574017: 745 8 1 2 38 9 5 4 32 5\r\n3733590: 362 8 71 898 966\r\n72571864: 1 9 5 2 67 5 95 3 6 60 3\r\n1090293987487: 249 2 306 2 4 40 547 5\r\n33969733: 7 69 8 107 813 4 82 2 1\r\n4800417: 1 6 72 74 1 821 30\r\n1501: 26 6 343 940 62\r\n98458441278: 6 84 834 7 7 2 9 3 5 8 9 9\r\n309974: 4 9 1 6 5 5 2 3 372 2 1 96\r\n36808: 97 370 1 910 7\r\n530432: 3 81 287 430\r\n88843104: 7 2 955 8 1 3 20 4 4 2 48\r\n179432322: 718 51 8 7 7 18 1 9 9\r\n3789361: 6 52 2 63 3 3 4 831 1\r\n32418: 37 6 4 49 2 2 2 7 7 7 97 9\r\n962310: 7 97 7 9 6 8 996 3 1 1 4 6\r\n45271: 88 473 315 51 595\r\n8504: 6 36 39 71 9\r\n401: 4 13 10 96 3 32\r\n56723641972: 649 874 1 103 1 972\r\n28801032: 3 4 4 344 896 82 8\r\n7760156856: 546 401 51 61 819\r\n4558: 4 2 894 9 4 1 851 4 4 55\r\n7905: 4 35 751 6\r\n11364228: 46 26 2 2 9 527\r\n12247841609400: 9 225 843 817 10 740\r\n8042: 12 2 60 622 2\r\n9883889603: 282 337 3 4 2 50 104\r\n525217881790: 812 93 673 6 1 9 2 96\r\n106890073: 8 9 1 47 94 7 3 7 8 51 8 1\r\n3968: 600 847 536 1 2\r\n27811757: 5 6 77 6 30 8 3 3 175 3 5\r\n3491: 7 4 46 9 634\r\n3516: 28 209 64 285 6\r\n22254825978: 941 3 8 6 4 5 7 9 77 9 7 6\r\n12927563: 425 72 203 2 9 26\r\n4242440: 4 611 40 14 23\r\n20416: 4 46 28 4 2 854 1 8 6 7 3\r\n2773560: 1 126 3 667 58 58 15 4\r\n362088213: 5 7 2 9 7 4 8 329 6 5 215\r\n83711640: 837 113 1 3 40\r\n17820: 7 3 2 5 297\r\n2431754: 22 79 98 54 20 1 9 537\r\n144576: 3 35 150 6 9 8 9 82 3 7\r\n508503: 72 639 7 19 9\r\n17527: 34 94 5 6 5\r\n39046779: 80 488 2 62 91 288\r\n184994439: 7 49 4 977 5 2 2 407 6\r\n18213: 8 1 8 9 75 16\r\n1357: 5 2 9 57 238 762 3 207\r\n128822080: 699 3 4 15 761 5 16\r\n661: 8 6 49 6 27\r\n6493802: 855 7 376 6 307 973\r\n6288328481: 5 1 44 4 5 8 674 60 4 7 1\r\n6856682: 68 56 672 9\r\n4027: 5 7 9 5 9 7 828 29 28 4 3\r\n48481040777: 7 882 9 5 9 8 41 1 3 7 1 9\r\n7259332289: 1 88 62 3 4 9 7 7 3 3 5 6\r\n1037903789: 188 70 97 8 55\r\n135590336: 102 903 7 16 92\r\n3550929783: 6 5 69 6 86 5 9 2 9 7 79 6\r\n3364209: 175 356 9 6 9\r\n567712100: 8 9 67 61 125 1 29 823\r\n15364831222: 30 714 5 78 3 1 149 73\r\n5616952: 9 7 92 316 919 10 7 7\r\n1309342320: 5 9 3 2 9 1 1 9 585 9 628\r\n1663646227: 8 2 636 46 227\r\n39984001: 51 23 20 289 600 9 3\r\n2786622208902: 66 57 14 69 823 8 9\r\n820892: 8 2 1 1 7 9 4 2 800 8 9 20\r\n18440: 118 55 11 1 1 28\r\n541423707: 86 7 460 68 2 2 569 3\r\n1913097: 31 3 2 429 3 22 6 8 94\r\n22167668600: 8 869 685 5 931\r\n1468390473: 31 9 887 417 302 3 1 4\r\n13410: 87 78 9 5 9\r\n580330: 1 230 502 76 5 140\r\n1092769: 57 396 8 42 1 298\r\n688: 648 1 21 19\r\n27324023314: 69 72 55 233 12\r\n370705: 674 55 5\r\n160293312: 9 44 7 9 8 257 7 93 94 4\r\n1724800: 955 95 50 4 392\r\n536452: 703 1 62 4 39 6 983 92\r\n39331: 940 101 80 35 96\r\n2560602548: 8 36 3 1 4 980 2 2 17 6 9\r\n7227552: 91 7 125 4 948\r\n1775554560: 4 1 684 8 6 169 8 2 5\r\n36913752: 4 7 7 3 4 95 7 5 284 3 3 3\r\n60062: 1 37 319 5 5 80 942\r\n1799958587: 785 4 8 1 5 505 24 451\r\n176: 3 5 2 79 1 80\r\n198712320488: 539 8 3 1 8 600 8 3 9 2 4\r\n4131631: 4 1 31 629 4\r\n9507600: 43 927 550 45 139\r\n1561110147: 739 5 8 1 4 2 528\r\n12869: 1 917 3 13 909\r\n300413382: 8 4 57 3 4 732 11 50 32\r\n14045483: 5 28 4 54 82\r\n6913138421126: 9 4 83 594 20 6 4 158 9\r\n16994502: 90 79 92 2 502 2\r\n183038: 8 1 6 1 4 7 8 17 6 2 93 14\r\n1239040: 8 871 72 88 2\r\n185571259: 6 767 18 3 8 1 5 2 9 3 7 7\r\n23180002: 347 997 67 18 731\r\n57746637: 55 6 532 12 887 663\r\n91254: 570 80 2 54 1\r\n1253723: 92 33 2 959 764\r\n36850959: 451 4 907 336 6 8 3 9\r\n1174211: 4 901 57 1 5 37 64\r\n69004260: 3 9 9 6 4 2 174 51 4 3 1 9\r\n259364: 23 3 150 6 25 57 9 5\r\n281531220: 40 8 5 88 743 39 43 51\r\n8631: 6 188 337 2 426 9\r\n4897083: 381 7 1 612 4 9 77 67 3\r\n284438: 80 8 5 2 44 9 99 2 1 5 83\r\n21492: 7 6 722 5 20 7 27\r\n520022: 821 633 21 89 2 217\r\n729468: 2 453 92 764 414\r\n7650: 40 1 8 97 18\r\n1530209924: 3 9 363 88 8 7 8 4 992 4\r\n124416: 2 175 8 80 9 7 2 2 349 9\r\n183173861: 6 5 5 944 63 4 7 2 7 3 1\r\n9636: 6 149 2 67 6\r\n440408841: 1 9 668 4 57 866 289 7\r\n272214: 648 42 10 1 55\r\n41122: 62 7 5 8 84 8\r\n1886950249797: 37 68 869 925 623\r\n4650693555: 6 9 674 93 555\r\n347603589: 14 14 812 4 927 9 93\r\n12579782579: 6 93 5 876 810 18\r\n212337312: 3 69 907 228 836\r\n114237: 77 7 49 6 3\r\n4211: 6 4 1 5 99 66 8\r\n3560494: 5 91 3 69 3 48 88 35 7 2\r\n2852256: 895 59 9 9 50 6\r\n136441244: 55 79 314 82 47\r\n266623: 266 5 48 5 69\r\n1017: 5 60 78 639\r\n383943416264: 444 6 411 769 456 8\r\n2353506: 14 90 41 23 7 556 77 1\r\n58826: 633 97 5 80 26\r\n49305: 7 870 9 4 8 481\r\n355445: 1 56 52 7 2 146 17 213\r\n81050765: 221 81 497 6 90 1 5\r\n196618130: 9 53 9 949 420 6 7 53 2\r\n82522653: 4 1 312 806 2 7 3 54 15\r\n2436676: 9 97 3 18 26 915 1 30\r\n1700707: 6 350 43 18 1 787\r\n598623: 4 47 2 6 4 4 1 9 7 2 458 4\r\n315889075: 9 5 6 8 4 3 14 647 4 94 7\r\n827996: 4 45 80 40 9 89 9 2 8 8 2\r\n67: 1 4 9 47 6 1\r\n240444: 8 4 43 22 5 19\r\n22373: 8 77 4 7 9 9 62 3 34 26\r\n18409188: 572 5 15 709 1 3\r\n890: 122 42 5 1 55 7 8\r\n42805855970: 6 4 7 8 8 2 8 6 3 55 1 968\r\n177840381: 2 45 19 2 52 381\r\n1065466092: 7 573 716 371 96\r\n569481204: 5 694 80 456 748\r\n6557760: 177 318 368 9 4\r\n72785543: 3 77 350 77 8 545\r\n15787: 537 28 424 1 326\r\n4337983: 88 31 217 8 56 23\r\n135743: 1 8 336 974 39 45\r\n1864911: 60 2 42 3 37\r\n550325433: 9 3 5 75 1 8 4 587 9 3 3 4\r\n4087664: 8 7 6 51 7 7 1 2 142 6 7 8\r\n2035380: 19 7 51 83 77 3\r\n1073380: 4 2 5 9 63 2 154 82 1\r\n13276620: 106 574 3 26 51 4 7 2 9\r\n7105: 1 14 7 8 20 6 6 7 7\r\n493645896073: 493 645 8 9 606 1 1 7 6\r\n34037828751334: 381 5 9 892 7 513 27 7\r\n2347950: 47 44 778 55 15\r\n569296: 981 5 58 26\r\n77163: 397 366 8 65\r\n144310617363: 576 874 9 4 50 5 819 7\r\n23128: 5 2 1 21 826 1\r\n416625193: 5 65 3 8 9 8 85 81 4 71 2\r\n313411: 1 51 846 349 6\r\n18739179715: 36 557 12 466 11\r\n290960: 59 27 952 8 4 7 97\r\n132876325382: 88 584 216 92 5 3 1\r\n18302287: 1 478 4 3 9 4 1 1 952 85\r\n2725620: 533 9 5 17 455 6\r\n141463: 1 2 6 46 1 6 8 2 21 1 6 1\r\n867151509124: 135 492 4 23 3 64 4\r\n338211: 2 72 587 4 99\r\n15744169381: 70 6 223 3 6 93 80\r\n41584400: 13 202 5 65 4 727\r\n577125008: 729 696 500 81 6\r\n2088583: 34 99 252 8 576 7\r\n206496059697: 60 9 478 8 59 69 7 1\r\n451453008: 31 909 522 5 48 6 44\r\n7791467: 4 2 7 3 2 2 663 1 4 2 37 8\r\n170162: 527 1 6 458 47 4 5 2 8 3\r\n258996371: 18 48 4 14 5 8 6 4 4 7 8\r\n13085344: 981 40 3 26 3 23 2 92\r\n99589590144: 14 2 54 49 297 4 8 36\r\n91109213: 91 10 921 1\r\n18246445: 56 61 126 8 7 67 5 31\r\n4005150060: 809 71 7 42 1 6 3 332 5\r\n14457163: 48 3 571 56 4\r\n1210255: 810 83 2 18 79\r\n191595: 636 3 8 4 416 45 250\r\n172873048: 755 56 487 943 565 7\r\n53482808: 3 8 4 2 5 1 370 4 3 3 6 5\r\n500268: 29 49 352 76\r\n5265: 449 17 60 1 3\r\n99110: 1 80 2 984 85\r\n2317: 3 8 36 157 4\r\n19716402939: 46 529 2 70 382 9 9\r\n16339245: 1 7 96 1 9 246\r\n918126: 3 489 5 4 622 45 9\r\n45514: 7 51 8 1 38 1 9 6 9 21\r\n5603955: 92 50 6 539 57\r\n373: 46 8 1 3 2\r\n9066632842: 896 1 6 8 8 908 3 2 84 1\r\n5091897954: 1 119 948 6 2 8 9 4 95 5\r\n3325917018: 330 62 67 847 21 18\r\n38622: 962 8 3 5 113 9 3 2\r\n49762971: 1 4 9 3 9 2 8 198 88 2 7 3\r\n14458026011: 61 2 410 9 57 852 40 9\r\n741: 7 2 6 60 597\r\n118125: 4 80 369 42 3\r\n879072: 65 796 5 4 15 883 7 1 9\r\n12673024: 1 728 68 4 8 8\r\n10462794933: 4 16 60 23 161 9 7 90\r\n76824: 8 97 1 99\r\n4130: 23 17 67 1 224 9 71 9\r\n36500020: 71 2 8 75 164 494 821\r\n1487012: 29 9 6 5 2 2 9 5 7 8 5 89\r\n4921597832: 34 9 1 32 397 29 439 1\r\n1508058874: 7 93 9 7 5 7 34 6 83 4 5\r\n39506253: 4 514 8 2 9 8 243 2 593\r\n1365451960: 92 2 265 4 7 8 7 62 9 4 1\r\n2799285: 3 1 4 9 37 16 9 2 9 21 2 4\r\n6670093: 950 59 9 8 819 87 70\r\n38775817: 10 9 455 8 940 5 7 2 7 8\r\n14328: 1 9 190 9 8\r\n852135: 4 5 81 37 76 33 3\r\n7142256: 29 8 62 4 501 4 9\r\n26338800: 94 8 3 467 25\r\n72600: 2 9 8 8 7 1 57 688 3 2 2 2\r\n64749724: 997 902 8 9 556\r\n1326048: 46 86 604 9\r\n5671: 8 8 32 8 1 9 2 6 9 5 977\r\n9203: 7 4 824 68 71\r\n127988: 30 560 660 824 7\r\n164: 4 4 2 145 3\r\n1062409: 9 83 17 7 1 49 160 40 9\r\n17976758976: 9 6 4 12 6 738 8 466 9\r\n859: 1 7 70 5 84\r\n4058: 2 62 6 31 28\r\n159656700: 6 6 80 9 7 5 9 5 7 7 175 1\r\n648108650: 94 626 12 9 212 436\r\n5259206: 9 8 2 60 8 6 7 367 1 95\r\n7698040119: 7 303 9 601 671\r\n251898349: 77 9 94 1 344 1 560 6\r\n1764325590: 4 71 8 664 351 5 21 92\r\n7281855336187: 79 57 536 431 7 184\r\n6227122235: 1 921 8 7 7 5 241 44 8 1\r\n104601704: 7 42 73 416 9 8 1 229\r\n252332424: 3 417 927 9 1 549 7 8 9\r\n19873: 879 69 1 92 19 94\r\n88433953: 595 6 4 9 56 1 619 515\r\n247799: 253 1 1 6 4 51 8 6 4 96 4\r\n9300: 8 4 1 1 71 1 5 1 34 3 9 9\r\n2926326347: 97 544 2 3 34 6\r\n17243835: 4 9 275 84 33 4 399 5\r\n644078: 93 8 8 3 3 9 12 7 1 606\r\n144978: 72 488 2\r\n436611: 5 24 452 336 8 3\r\n15957545: 18 86 907 65 4 5\r\n6034784862: 65 182 1 3 84 345 17\r\n3969895: 4 99 9 855 42\r\n7040: 746 938 64 4 48\r\n151468: 6 462 7 5 7 2 689 7 1 38\r\n2953: 4 6 5 50\r\n249514304: 47 551 8 68 767\r\n1021: 1 1 3 187 814\r\n57: 7 4 5\r\n178105: 97 2 3 903 214\r\n63149224: 5 9 750 56 369 4 6 6 28\r\n7750: 2 8 8 4 82 44 9 2 8 4 795\r\n452140: 9 33 1 7 481\r\n113138158: 9 568 86 57 40\r\n131941170: 68 8 379 506 657\r\n4804: 55 9 62 9 769 60\r\n166254470723: 1 494 549 3 5 471 613\r\n1670599: 2 51 93 2 2 44 2 882 5\r\n1655316816: 7 362 1 9 5 6 566 23 7\r\n91505: 9 15 2 173 414 11\r\n212587980: 58 66 2 841 66\r\n932702: 60 5 4 863 704\r\n1662189580863: 84 4 53 7 7 6 7 6 8 3 6 1\r\n5537108: 530 269 77 2 9 21 1\r\n466712: 5 164 58 514 4\r\n8979: 897 1 4 2\r\n1092529: 2 540 10 43 295 36\r\n2826835208: 7 1 6 4 9 75 4 7 779 7 1 1\r\n4353848242: 3 6 3 5 886 5 4 13 7 9 4 9\r\n687048: 68 728 863 1 99\r\n66072: 71 5 377 89 917 7\r\n96698: 61 25 9 2 62 1 9 5 3 7 7\r\n454883302: 5 2 81 3 9 76 2 409 45 1\r\n95463200: 45 2 7 29 1 5 9 1 4 6 2 1\r\n625131648: 34 942 15 593 864 72\r\n8913: 8 855 9 49 1\r\n6976116: 47 31 2 9 266\r\n10728897: 81 4 7 316 5 8 2 5 1 3 9 3\r\n269082270: 7 491 3 540 33 197 43\r\n5170579: 51 661 9 35 79\r\n3992014: 426 902 501 6 44\r\n5350: 5 7 1 14 7 6 4 7 6 305 5\r\n4746484351: 5 81 2 97 466 6 73 43\r\n35119: 48 7 6 1 3 74 7\r\n7038900: 4 51 54 30 79\r\n3508: 2 907 5 52 3 610\r\n361179: 99 4 5 40 819\r\n4399417: 756 7 2 442 399 43\r\n3047859: 43 529 7 9 776 33 9\r\n121833190: 1 7 2 6 7 2 237 8 7 184 3\r\n178252209: 3 1 138 46 5 9 1 3 4 52 5\r\n66336839: 7 608 50 1 52 478 18\r\n66872: 471 920 6 13 8\r\n1015256720: 8 39 5 2 6 278 2 4 6 7 5 2\r\n251: 3 4 3 3 144\r\n31014766: 42 6 4 751 3 8 37 3 13 9\r\n6555654: 4 724 10 189 47\r\n14524926: 53 6 23 8 7 2 5 49 8 31\r\n914760: 1 3 492 66 28\r\n4792: 80 6 192 6 1 6 718\r\n1723: 8 25 7 41 991 11 469 4\r\n2997: 3 29 245 9 9\r\n107126161282: 252 576 4 1 4 738 85\r\n6111633: 67 84 475 8 635\r\n3079965: 75 1 5 2 182 8 4 3 6 8 1\r\n6254672774: 5 4 708 2 7 306 8 4 7 77\r\n174202438500: 409 594 4 3 155 2 771\r\n27365627611: 383 272 4 3 7 8 5 17 6 5\r\n4832905: 6 6 38 2 171 505 6 11 5\r\n247767: 62 2 254 776 71 928\r\n729392: 3 56 13 33 865 2 2\r\n135329: 371 91 28 4 173\r\n253728382: 21 21 9 8 9 9 71 1 4 638\r\n1261462464: 1 63 95 5 6 974 2 1 9 2 6\r\n1691650192: 4 4 8 9 2 5 9 37 2 541 7 4\r\n816920: 3 882 84 3 15 7 6 49 8\r\n762754367: 3 602 36 7 4 3 1 6 41\r\n9792171027: 831 6 918 9 6 708 7 3 6\r\n422095: 76 30 56 9 71\r\n15670: 2 4 144 6 67\r\n1098607941: 2 6 3 7 3 5 21 4 751 3 9 9\r\n56135877: 5 1 212 9 8 5 2 883 1 4 7\r\n47: 1 8 6\r\n8424: 79 4 1 2 6\r\n40613332: 160 6 8 66 70 635\r\n172730906: 6 51 7 7 128 2 5 9 18 8\r\n30165392250: 9 3 589 2 5 4 7 6 7 5 645\r\n3160792: 3 9 321 12 952 67\r\n278437652: 6 464 3 1 756 9 82 2\r\n95: 9 9 16\r\n16160: 99 3 132 76 8 4\r\n80634: 28 4 8 166 4 954\r\n619542: 9 5 764 85 9 657\r\n30308213418: 6 7 6 615 8 2 97 7 8 3 7 6\r\n785: 313 305 156 4 7\r\n4297503668: 8 4 3 3 2 6 358 57 6 8\r\n21085110: 6 468 72 8 9 39 5 162\r\n358865943072743: 452 56 5 944 8 84 745\r\n6938002: 96 146 99 5 82\r\n89670243: 9 3 6 860 7 3 55 4 459 3\r\n138833049675: 8 6 850 9 83 2 378 72\r\n1851300: 65 1 55 34 15\r\n14518: 1 7 29 202 61\r\n2045480: 32 2 1 3 8 752 3 5 15 2 8\r\n323839650237: 6 935 8 995 536 667 7\r\n1054: 19 55 9\r\n253222253: 21 184 6 6 1 4 442 9 5\r\n5180: 850 545 4 7 907 277 2\r\n70841: 3 59 5 5 8\r\n2593938251: 3 48 87 87 650 5\r\n22103506534: 1 7 7 1 5 3 961 50 6 536\r\n6795: 311 19 7 872 7\r\n66586334430: 32 9 4 3 56 1 3 41 8 8 70\r\n7237755: 5 88 8 5 5 2 4 60 7 5 4 45\r\n403886069: 216 3 57 979 867 3 6 2\r\n69806713: 13 4 1 247 891 232\r\n190661651: 5 1 53 37 651\r\n99005259: 328 105 820 99 28 59\r\n224649: 6 13 8 360 6\r\n191059425: 41 67 966 8 9 9\r\n5083216: 1 9 622 3 24 2 8 2 68 80\r\n5166000: 7 116 5 240 7 5\r\n368016109: 8 2 12 374 108\r\n35631897: 8 3 66 7 128 1 159 996\r\n55577277: 958 21 7 58 694\r\n6572928: 657 2 92 6\r\n632016: 723 1 380 9 92 4 63\r\n2437790: 8 4 432 2 7 4 8 6 2 88 7 7\r\n36319489: 3 73 86 65 229 8 87 3\r\n996152332: 3 7 9 1 9 28 914 5 2 334\r\n5331: 872 12 5 908\r\n319763557: 546 3 69 24 578 85\r\n4038142687337: 258 846 9 3 26 6 733 7\r\n47674: 2 74 393 7 87\r\n120433: 2 678 759 12 83\r\n333018: 95 1 2 65 114 26 7 2 3 3\r\n70985: 65 2 2 7 93 5 22\r\n37811: 7 14 54 5 4 9 5 2 3 5 52 9\r\n61582362: 8 3 9 4 6 5 2 37 6 58 69\r\n487: 81 5 82\r\n41754942: 987 76 4 982 1 300\r\n5295876061: 6 21 3 4 75 65 6 4 5 5 3\r\n7398214: 9 4 485 142 11\r\n34704975: 66 7 5 28 7 85 7 3 9 16\r\n1114: 29 45 5 3 4\r\n66152: 3 71 41 709 3\r\n15727312167: 748 9 196 27 21\r\n7801998: 500 16 70 54 1 4 78\r\n977319222: 13 47 338 5 517 473 2\r\n11872: 4 8 794 862 8 7\r\n1370334: 12 53 254 7 3\r\n1582154: 3 3 8 1 787 73 9 2 3 1 7 6\r\n16954859: 764 73 16 5 4 19\r\n176723591: 8 12 97 5 4 5 39 3 2 6\r\n1300432: 6 677 8 34 7\r\n188059782: 430 90 676 8 597 6\r\n438453132: 4 62 2 5 6 7 646 696 39\r\n7066: 531 2 6 1 4 1 80 8 5 596\r\n230771: 2 511 9 442 47\r\n24032130: 3 997 3 4 8 123 6\r\n213283675: 53 32 8 4 5 8 7 5 8 2 3 5\r\n2211: 43 1 23 9 2 99 917 9 2 5\r\n1378330: 3 75 844 3 6 34 5 71 3 8\r\n10410469186: 115 665 6 879 9 7 1 2 3\r\n2757678: 3 22 715 32 22 1 7\r\n6407054: 82 4 7 4 8 4 347 9 9 2 2 6\r\n3478020: 713 116 58 44 7 6\r\n2344259: 7 2 26 92 70 69 30\r\n7846: 4 84 21 9 781\r\n75283: 752 1 6 4 6\r\n6055: 1 7 8 9 7 70 3 93 1 359\r\n133182625: 8 9 8 1 4 20 328 5 37 1 4\r\n9491: 42 62 9 24 9 9 834 8\r\n362376: 752 17 89 69 28\r\n688744: 5 766 891 853 930\r\n15228941018806: 94 162 94 101 8 806\r\n75274237: 6 90 2 785 762 70\r\n1620: 3 7 5 5 71 8 2 3 1 4 93 89\r\n187691197: 209 55 53 3 149 7 44 1\r\n1372482488: 761 3 22 9 652 194\r\n539876: 3 45 4 4 971\r\n88803001: 7 98 3 932 990 30\r\n64383625: 3 30 8 166 23 68\r\n489: 8 14 307 51 1 18\r\n6240563: 93 57 1 2 8 6 98 7 700\r\n312517788: 52 76 55 336 790 901\r\n683735489367: 869 89 2 496 655 6 84\r\n126650: 4 74 2 5 85\r\n172256657874: 8 6 2 256 65 78 77\r\n55093: 909 548 32 37\r\n1656428: 113 52 641 7 10\r\n3066: 3 34 9 6 57\r\n24706408: 5 54 3 9 445 5\r\n3714913249: 829 8 9 5 3 56 41 238 9\r\n16252190667: 8 2 45 970 5 254 6 6 1 9\r\n4805541: 1 843 475 33 4 15 3\r\n73: 10 1 7\r\n218831426946: 1 2 133 9 3 1 8 6 5 334 7\r\n54397619: 62 525 174 5 868\r\n9241607668: 924 1 607 563 12 7 86\r\n214: 4 86 1 67 56\r\n8707235831: 9 62 59 449 39 9 58 31\r\n1165: 523 6 5 2 63 34\r\n210956368: 47 34 691 4 92 35 5 13\r\n227725870: 227 72 558 6 9 221\r\n3675502185: 93 8 758 56 5 645\r\n59969697559: 995 3 9 6 592 9 7 559\r\n45603: 2 3 8 3 7 2 8 34 10 6 7 31\r\n17262850: 896 9 33 578 880\r\n3897906: 5 44 5 710 4\r\n12730524454: 553 17 23 761 4 451\r\n245677: 339 1 5 713 405\r\n3465742: 81 4 8 70 878 979 82\r\n12524: 78 4 4 16 5 443 1\r\n3695: 36 9 5 2 5\r\n201848024: 1 5 4 7 4 824 3 6 1 7 15 7\r\n104520: 5 1 4 5 871\r\n56020722: 3 9 54 1 2 407 64 98 2\r\n105179740872: 58 2 80 6 6 378 75 9\r\n5290608161696: 775 476 1 8 8 1 6 2 533\r\n232737864: 34 7 65 963 3 76 2 4\r\n242592: 3 42 77 4 511 2 4 4 84 2\r\n2400: 86 3 311 6\r\n848250: 7 829 6 530 513 2 25 9\r\n14116656: 5 25 394 537 62\r\n20677761000: 2 351 269 10 1 50 219\r\n177040: 3 6 13 49 6\r\n14388: 8 359 3 952 2 7\r\n3993004: 42 27 27 859 9 936 7 4\r\n3316: 59 274 7 968 4 7 6\r\n2291535: 5 1 78 605 97 6 45\r\n4891072: 60 7 663 67 70\r\n6073461828: 60 4 3 1 3 4 61 8 3 10\r\n62154540: 35 761 8 6 441 174\r\n35498: 9 298 6 9 9 1 57 2 5 6 5 3\r\n403573924: 401 2 482 91 925\r\n2554422: 50 5 32 39 102 7 78\r\n12839262054: 7 9 74 642 323 24 5 56\r\n1488: 88 584 300 439 77\r\n3785: 16 1 124 27 1 4\r\n182270: 91 2 24 8 6 16\r\n44240820: 4 7 14 889 51 905 39\r\n152290857209: 2 9 89 59 2 9 857 210 1\r\n249218965: 98 5 429 412 3 7 1 8\r\n4866048: 9 9 92 66 9\r\n2504398: 6 67 6 500 860 75\r\n4618017460: 3 7 5 9 8 3 7 85 44 4 9 65\r\n16567778880: 2 4 1 79 696 15 8 279\r\n55556: 57 91 907 9 710\r\n347423477: 53 2 441 175 357\r\n285: 8 4 9\r\n186356532: 1 2 8 91 9 2 2 1 9 93 436\r\n58803685: 7 1 7 2 6 7 490 32 1 6 8 6\r\n1309434: 495 880 878 1 3\r\n178509: 3 81 4 6 3 7 7\r\n846661: 70 7 1 7 5 768 2 325\r\n25227772: 4 910 3 46 9 135 770\r\n1190612: 901 11 31 6 36 854 34\r\n232694: 173 3 8 8 8 9 7 40 4 7 4 8\r\n166664864: 166 577 8 870 6 1\r\n1019289600: 6 8 1 3 87 4 8 1 2 896 96\r\n3358431: 72 52 7 96 873 1\r\n91776033: 95 60 96 28 6\r\n786603: 7 5 50 1 927 4 3 8 9 5\r\n17824: 91 8 5 1 9 9 3 141 46 3 9\r\n8275465002: 8 4 862 1 5 73 326 5 4 3\r\n1172109456: 35 7 8 6 4 850 7 6 3 56\r\n1188: 895 14 269 5 5\r\n85155840: 3 2 7 960 48 44\r\n3174080729: 172 914 4 28 104 731\r\n362835922: 24 4 1 6 514 769 5 922\r\n576796: 2 8 91 9 5 44\r\n4148469: 2 8 85 714 4 4 2 44 5 36\r\n37308: 8 7 361 98 8 439 7 6\r\n30157132500: 220 285 583 33 25\r\n277551719: 27 755 1 5 1 20 1 509 7\r\n1127070459: 91 4 565 8 6 99 9 75 3 3\r\n63987740: 6 6 69 58 504 906\r\n76945954: 54 727 98 3 6 5 9 9 5 4 2\r\n1916249: 75 68 375 50 7\r\n89878712: 3 8 887 78 696 17\r\n61599828: 99 703 82 8 24 820 87\r\n139002786: 5 3 5 6 6 8 440 72 822 7\r\n190398146: 45 6 6 1 81 44 9 2 852 2\r\n1151436492: 493 153 81 6 6 40 9 55\r\n477540334: 4 3 3 8 60 91 5 8 8 4 218\r\n199692: 515 745 22 805 7 17\r\n256733063440: 6 4 1 73 994 898 394\r\n3778: 6 629 2 2\r\n5305497: 32 66 9 60 27\r\n7472238005: 4 8 6 7 5 9 724 24 515 5\r\n4241875: 4 601 4 44 33 56 8 47 5\r\n7398: 7 27 550 6\r\n610239350: 1 7 7 94 24 5 670 5 53\r\n386: 36 1 64 93 2\r\n1089588: 3 43 83 4 7 2 82 2 4 606\r\n334377247: 4 29 332 436 10 6 7 85\r\n12780096: 2 84 37 4 514\r\n143323226904: 887 529 4 979 78\r\n23521: 655 7 203 437 9 2 85\r\n824354465: 850 726 1 323 3\r\n465034: 9 28 71 5 676\r\n6481: 53 5 4 24 25\r\n530535: 12 1 570 50 77 5\r\n253290: 3 466 90 5 6\r\n125167488: 8 81 6 1 5 9 5 201 6 128\r\n7634617: 40 9 651 45 239\r\n2664630: 6 8 26 9 4 33 9 7 279 7\r\n11433798: 5 861 3 27 163\r\n1402993: 56 84 2 9 62 34\r\n2290691532198: 884 366 708 7 5 195\r\n824555160: 95 843 13 22 6 6\r\n94102706908: 73 5 8 423 37 7 252 2 9\r\n4377618265: 9 356 6 1 9 6 74 9 6 47 5\r\n23265828315: 9 5 1 517 823 3 2 3 14\r\n11356352700: 7 9 46 8 4 6 32 635 770\r\n356085: 422 5 7 1 58 5 8 3 84 3 6\r\n4931918: 5 37 9 9 9 8 921\r\n3984130198: 432 7 155 1 2 850\r\n12697092: 4 5 6 9 1 4 9 137 17 9 76\r\n2044220: 147 57 4 2 23\r\n8403733467: 822 19 60 472 19 26\r\n1941410931: 5 8 86 2 321 4 6 2 9 2 7 1\r\n2477: 1 6 5 8 9 5 4 2 4 529 8 28\r\n11003235877: 4 7 9 8 5 984 9 491 16\r\n166704731505: 5 49 4 6 5 8 34 7 4 505\r\n3409653: 6 1 5 746 873 5 1 588\r\n7892463: 5 695 41 142 75 813 1\r\n331807: 63 8 1 25 7 980 40 1 5 2\r\n111260906: 528 439 3 2 25 24\r\n28768890: 455 655 319 675 63\r\n9285066: 8 9 5 1 71 583 86 354\r\n621431805570: 621 1 3 31 805 571\r\n428953: 3 16 182 7 8 7 1 4 5 4 8 7\r\n828786: 3 3 12 456 78 99 83 4\r\n194276336: 93 101 276 3 32 2\r\n4786009982: 92 94 736 333 3 51\r\n44271360: 685 34 501 3 9 3 8 8 7\r\n1048274530: 701 78 5 27 2 710\r\n7172929: 96 53 4 27 8 6 14 52 6\r\n149277925: 4 967 8 93 3 24 1\r\n58409: 96 76 8 1 40\r\n10374: 206 104 79 1 9 1 26\r\n2505109320: 3 3 63 5 895 5 7 87 2 3 2\r\n1360: 1 156 13 2 4\r\n2595413: 4 9 62 5 57 1 7 93 9 7 2\r\n403: 4 1 7 10 54\r\n1488180: 92 53 5 61 993 7\r\n12957476498: 7 948 5 667 16 843\r\n1344925707: 39 54 824 8 36 5 155 7\r\n7966778: 4 8 5 83 9 80 49 4 3 1 2\r\n2375827856: 9 9 5 875 431 7 837 8 8\r\n27957911: 617 1 6 4 2 3 6 7 6 3 78 8\r\n237223914051: 941 2 7 2 9 5 3 10 5 7 9 7\r\n1172738569: 2 27 3 5 85 7 2 7 5 8 9\r\n30660: 265 9 30 2 62\r\n285756027: 437 5 63 728 9 7 5 1 2 5\r\n17086928567: 8 552 9 6 7 7 8 3 2 185 7\r\n2387: 10 21 77\r\n1670627: 839 949 87 9 99 2\r\n89494: 887 53 740\r\n135578: 1 2 53 71 37 3\r\n61755521: 7 7 19 44 80\r\n2358541152: 8 2 927 41 3 21 325 5 5\r\n5298268754: 2 53 771 25 95 5\r\n85910976020738: 83 599 6 480 6 20 738\r\n238388504: 617 5 636 1 350 2\r\n352536: 3 8 7 461 7 16 5 296\r\n3524933: 5 7 3 11 1 534\r\n41545238: 312 951 3 6 2 328 92 7\r\n29538040: 216 1 1 2 332 5 41\r\n1571: 6 3 981 7 565\r\n2298505736: 60 8 4 5 5 5 1 44 3 42 9\r\n5015664: 683 984 5 449 571\r\n2837727: 6 7 2 3 6 4 1 7 508 5 33 5\r\n80700: 87 3 8 6 50\r\n79288: 74 62 583\r\n2632052: 6 2 8 9 159 28 500 2 50\r\n29028249: 44 83 2 3 716 1 72 3 3\r\n1466917: 4 159 76 96 8 93 529\r\n207155776894: 28 9 28 32 72 8 896\r\n279655113: 4 1 36 91 676\r\n54529524686: 2 7 2 1 7 2 9 9 48 6 6 685\r\n11990: 123 45 3 3 7\r\n87785: 602 798 63 6 7\r\n216797: 598 55 83 4 1\r\n12141829: 63 2 3 6 2 8 4 280 8 29 5\r\n62153: 4 5 69 79 26 65 7 2 91\r\n5812: 1 45 9 1 940 9 5 5 772\r\n33338: 1 97 340 1 9 8\r\n107101: 2 17 7 5 9 4 49 5 259 17\r\n211172238477: 2 377 314 55 5 98 568\r\n1116700: 10 21 318 772 859\r\n7642: 68 731 8 41 393 810 6\r\n3226: 8 1 92 5 5 5 3 9 1 684\r\n3817752: 4 117 8 56 9 98 72 456\r\n6222091: 3 1 6 600 3 6 16 7 4 3 55\r\n32374438: 7 611 536 3 2 8 330 84\r\n9810623: 15 82 62 5 9 15 807\r\n3182651: 102 55 9 3 3 210 7 310\r\n46136: 98 50 867 2 4\r\n889: 4 80 2 4 456 9 252\r\n190049605020: 6 3 77 4 25 82 837 990\r\n37792782: 3 8 37 1 55 4 4 1 95 4 3\r\n145: 28 2 99 5 5 6\r\n520636325: 95 305 28 5 4 981 62 5\r\n925375477: 70 9 8 5 5 32 5 1 5 47 7\r\n493290000: 573 7 7 375 324\r\n5457683: 8 737 32 93 85 61 9 1\r\n4910: 72 80 9 30 83\r\n2753378: 439 10 22 7 9 64 10 98\r\n34148611: 19 216 77 6 295\r\n94927: 419 55 6 5 2\r\n698310: 4 6 5 7 702 3 7 8 5 54 6 9\r\n58441239: 1 625 2 824 3 3 8 6 239\r\n7516692480: 128 66 83 8 2 670\r\n71106222600: 630 269 1 7 740 9 3 3\r\n47097301: 9 3 560 5 1 29 9 6 89 7 8\r\n3675: 6 9 52 10 47 31\r\n1110: 5 6 6 6 8 1 9 54 3 1 857 3\r\n241929: 2 690 125 863 144 4 5\r\n45665857: 4 189 1 5 4 9 6 46 8 3 1\r\n249745881: 63 931 1 9 251 8 82\r\n58080: 60 475 70 16 6\r\n7032: 5 9 2 70 6 390 1 2 792 4\r\n64588431014: 5 2 252 13 1 90 9 7 47\r\n1107: 2 9 1 98 75 922\r\n316740812186: 1 9 9 7 3 950 6 768 3 6 4\r\n8761545: 744 4 85 3 39\r\n2661552: 6 760 82 58 104 54\r\n12420: 3 16 50 9 5 4\r\n441291: 9 23 5 5 9 5 2 3 7 8 13 4\r\n8689115: 9 29 55 45 611 600 95\r\n168750031: 5 6 6 6 4 24 77 764\r\n843454122: 41 72 69 3 293\r\n3331057: 1 763 436 8 7\r\n2722: 12 5 4 3 911\r\n246216645857: 54 71 48 1 45 857\r\n29822010: 27 2 76 50 15 749 573\r\n36722: 36 994 1 621 8 38 270\r\n599783: 6 5 854 677 680 635\r\n9116: 2 8 2 7 4 935 8 164 8 9 3\r\n1295500: 568 30 76 379 81\r\n190581272802240: 6 82 5 329 655 87 8 7 7\r\n167125: 32 1 408 5 85\r\n81900: 4 13 25 63\r\n57580992: 5 3 138 9 2 7 302 5 8 8 9\r\n12458534: 5 6 6 6 19 14 35 33 334\r\n53964362670: 89 9 2 8 1 20 890 3 1\r\n62988461250: 1 2 9 39 5 922 4 5 9 7 8 4\r\n2132515606590: 3 1 533 5 155 3 7 658 7\r\n2326433: 2 945 6 6 1 8 5 3 17 8 8 9\r\n102471: 6 7 72 88 69\r\n13112251: 6 26 849 3 99\r\n137088990: 923 9 5 7 60 55 2 379 9\r\n1106: 63 1 1 6 20 452\r\n330692171: 464 96 486 9 2 59\r\n240410: 24 619 3 371 742\r\n589952: 58 8 286 419 4\r\n1231246333733: 8 7 8 61 77 29 373 6\r\n544204: 717 759 1\r\n1126: 5 539 2 31 7\r\n882445951: 882 445 183 766\r\n117360: 30 8 86 5 72\r\n744: 655 1 7 4 75\r\n18610177: 35 6 672 407 8 547 83\r\n2685190: 30 55 376 7 3 73 64 4 2\r\n198279075: 42 398 62 45 75\r\n401524: 410 977 1 48 905\r\n239616: 5 674 361 6 2 7 6 8 6 2 4\r\n11977700: 70 241 1 710\r\n143761806023: 157 9 8 455 27 2 6 22 1\r\n1483764964: 647 25 307 4 9 2 496 3\r\n960: 5 192 1\r\n16579224: 618 638 50 44 4 6\r\n40551: 6 4 37 2 3 2 2 7 527 2 7\r\n749408256: 58 4 79 9 5 87 3 8 128\r\n16836: 6 2 7 69 6 8 8 3 51 6\r\n61596335: 7 44 8 327 61\r\n16694732: 766 342 23 4 655 93\r\n46910122: 2 77 3 967 6 3 3 35 7 1\r\n1365: 21 3 618 686 37\r\n2226052193: 6 9 1 8 265 4 2 4 434 5 5\r\n14626832: 1 9 2 3 67 4 183 97 3 1 2\r\n3149: 945 3 57 5 252\r\n2018297: 6 1 5 71 812 477\r\n192942: 99 1 4 1 486\r\n5896806: 3 8 1 2 983 787 9 6 60 6\r\n33057839: 661 5 7 109 645 51 31\r\n45120753216: 4 2 281 6 6 6 44 3 919 6\r\n19541537: 2 4 48 724 8 1 401 62 5\r\n45348657692: 771 231 4 6 8 6 735\r\n95924806: 168 793 7 7 35 18 4\r\n305481940: 96 5 57 2 1 59 113 145\r\n12020061: 4 835 44 8 444 73 15 5\r\n15556114: 835 115 2 81 64\r\n14108160: 660 4 2 668 4\r\n3005447455: 3 7 568 2 4 74 57\r\n1856796984391: 4 58 4 77 68 6 7 7 39 2\r\n22602: 850 4 367 6 1\r\n123: 40 3 7 4 69\r\n54922: 6 12 20 461 817 3 5 8 2\r\n124872918: 821 11 6 25 7 1 721 17\r\n70: 10 4 5\r\n14626188: 4 9 9 8 3 435 84 9 9 6 7 3\r\n729247255952: 3 321 9 989 5 1 5 95 2\r\n103333: 47 56 1 3 34\r\n9596: 95 22 2 69\r\n25245: 9 200 724 4\r\n499804661: 1 923 9 89 30 3 2 338 5\r\n3603: 8 99 75 2 2 72 8 3 1 79\r\n2505244491: 4 4 814 9 95 69 7 9 2 7 9\r\n10917456: 27 8 71 3 55 59 4 8 62\r\n10409799088: 844 805 3 349 9 55 1 7\r\n280983: 1 16 7 5 8 2 3 7 66 67 20\r\n332909422: 3 7 17 71 8 877 6 11 5 4\r\n17499: 6 6 5 4 307 17 40\r\n3395084375: 45 44 95 9 1 747\r\n22993515036725: 19 2 7 65 190 9 36 724\r\n1506114504: 8 7 4 7 8 246 9 1 4 1 82 1\r\n2235273466: 9 3 2 47 6 2 22 734 6 1 5\r\n25156615: 3 8 5 5 363 42 6 632 83\r\n17866649: 84 4 395 514 9\r\n401544: 7 1 8 62 4 43 46\r\n18363214506: 7 7 2 782 6 392 8 35 78\r\n35340: 42 26 3 5 5 93\r\n711531503: 8 6 5 3 8 530 642 8 853\r\n9426965: 88 6 261 8 62\r\n430502730: 2 5 9 703 3 9 8 7 1 66 7 6\r\n10659: 2 8 6 1 4 9 365 9 1 3 57 5\r\n777903204: 3 26 84 12 7 5 7 5 1 4 4 3\r\n321354: 326 3 67 37 9 33\r\n11661: 20 90 1 3 21 87\r\n5289024: 528 83 7 20 7\r\n3814195207: 8 3 5 4 4 97 8 8 800 6 1 6\r\n47396388: 3 82 2 882 5 351 3 89\r\n45191: 928 8 6 5 641\r\n304: 8 19 2\r\n838493145898: 3 835 493 1 4 588 5 16\r\n105296498: 375 79 28 7 2 743 98\r\n922111246: 75 876 2 330 7 5 7 1 3 6\r\n73143515: 69 8 9 8 9 3 8 639 761 5\r\n25263914420: 508 48 635 439 163\r\n14103914: 91 75 116 38 731\r\n271021740033: 4 96 15 6 420 470 33\r\n28833984: 9 1 8 1 686 79 98 28 32\r\n211323894: 161 934 435 8 3\r\n83406960: 260 76 67 7 9\r\n9904924808: 78 6 7 6 9 4 6 3 12 5 4 6\r\n4754: 7 5 96 4 148\r\n2392: 83 3 67 55 146 9 63 9 4\r\n3897: 9 35 32 9 774\r\n60842: 14 97 8 930 58")
    {
        private List<string> parameters;
        protected override void Solve()
        {
            Splitlines();
            parameters = [];

            foreach (string equation in lines)
            {
                if (CheckEquation(equation))
                {
                    result += long.Parse(equation.Substring(0, equation.IndexOf(':')));
                }
            }
        }


        private bool CheckEquation(string equation)
        {
            long solution = long.Parse(equation.Substring(0, equation.IndexOf(':')));
            parameters = equation.Split(':')[1].Split(' ').ToList();
            parameters.RemoveAt(0); //remove empty space
            long param = long.Parse(parameters[0]);
            return TrySolutions(solution, param, 1);
        }

        private bool TrySolutions(long solution, long acc, int index)
        {
            if (acc > solution)
            {
                return false;
            }
            if (acc == solution && index == parameters.Count)
            {
                return true;
            }

            if (index < parameters.Count)
            {
                long param = long.Parse(parameters[index]);
                index++;
                return (part2 && TrySolutions(solution, long.Parse(acc.ToString() + param.ToString()), index)) ||
                    TrySolutions(solution, acc * param, index) || 
                    TrySolutions(solution, acc + param, index);
            }
            return false;
        }
    }
}