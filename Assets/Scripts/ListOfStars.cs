using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfStars
{
    public static string[] StarNames = new string[] {
        "Sirius", "Betelgeuse", "Rigel", "ProximaCentauri", "AlphaCentauri", "Altair",
"Antares", "Arcturus", "Achernar", "Achird", "Acrab", "Acrux", "Adhafera", "Ain", "Aladfar",
"Alamak", "Alathfar", "Albali", "Albireo", "Alchiba", "Alcor", "Alcyone", "Aldebaran", "Alderamin",
"Aldhibah", "Aldulfin", "Alfirk", "Algedi", "Algenib", "Algieba", "Algol", "Algorab", "Alhena",
"Aljanah", "Alkaid", "Alkalurops", "Alkes", "Almaak", "Alnair", "Alnasl", "Alnilam", "Alnitak",
"Alniyat", "Alphard", "Alphecca", "Alpheratz", "Alrai", "Alrisha", "Alsciaukat", "Alsephina",
"Alsuhail", "Altarf", "Aludra", "AlulaAustralis", "AlulaBorealis", "Alwaid", "Ankaa", "Anser",
"Anthea", "Antlia", "Apus", "Aquarius", "Aquila", "Ara", "Aries", "Arina", "Arp299", "Arp319",
"Ascella", "Aspidiske", "Asterion", "Asterope", "Atlas", "Atik", "Atsuk", "Atyches", "Auriga",
"Avior", "Axion", "BaadesWindow", "BarnardsStar", "BatenKaitos", "BayerAtlas", "Becrux",
"Bellatrix", "BetaAquilae", "BetaArietis", "BetaCancer", "BetaCapricorni", "BetaCassiopeiae",
"BetaCentauri", "BetaCephei", "BetaCrucis", "BetaGeminorum", "BetaHydri", "BetaLeonis",
"BetaLeporis", "BetaLyrae", "BetaOphiuchi", "BetaPavonis", "BetaPersei", "BetaPictoris",
"BetaReticuli", "BetaSculptoris", "BetaSerpentis", "BetaTauri", "BetaTrianguliAustralis",
"BetaUrsaeMajoris", "BetaUrsaeMinoris", "Betelgeuze", "Betria", "Bharani", "Bienor", "BinaryStars",
"BodesGalaxy", "BowTieNebula", "BoxNebula", "BradleysHead", "BrainNebula", "BubbleNebula", "BuddhasGhost",
"Buotes", "CanisMajor", "CanisMinor", "Canopus", "Carina", "Cassiopeia", "Castor", "CatsEyeNebula",
"CentaurusA", "Chameleon", "ChaosDwarf", "Cepheus", "Cetus", "Chamaeleon", "ChandrasVariableStar",
"Chara", "Charybdis", "Circinus", "CitadelCluster", "CocoonNebula", "Coalsack", "Collinder69",
"CometNebula", "CoronaAustralis", "CoronaBorealis", "Corvus", "CrabNebula", "Crater", "Crux",
"CurtisCross", "Damocles", "Deneb", "DenebAlgedi", "Denebola", "Deimos", "Delphinus",
"DeltaCancri", "DeltaCorvi", "DeltaSagittae", "DeltaSerpentis", "Deni", "Diphda",
"DisPater", "Dorado", "DoubleCluster", "Draco", "DumbbellNebula", "Earth", "ElGordoblob",
"ElNath", "EllipticalGalaxies", "Elrathia", "EmperorGalaxy", "Enif", "EpsilonAurigae",
"EpsilonCarinae", "EpsilonEridani", "EpsilonGemini", "EpsilonIndi", "EpsilonLyrae", "EpsilonPegasi",
"EpsilonPersei", "EpsilonScorpii", "EpsilonTauri", "Equuleus", "Eridanus", "Erinome", "Escorial", "EstrellaMussalen",
"EtaAurigae", "EtaCarinae", "EtaCephei", "EtaCorvi", "EtaDraconis", "EtaEridani", "EtaGemini", "EtaGruis", "EtaHydri",
"EtaLeonis", "EtaLupi", "EtaOphiuchi", "EtaPegasi", "EtaPersei", "EtaSerpentis", "EtaTauri", "EtaUrsaeMajoris", "Ethos",
"ExtinctionNebula", "FairchildNebula", "FairieRingNebula", "Fath", "Fomalhaut", "ForamenMagnum", "Fornax", "FouriersKnot",
"FoxheadCluster", "FractalNebula", "FrostyLeo", "Fuji", "Funis", "Gacrux", "GalexyGoddess", "Galaxy", "GammaAndromedae", "GammaAquilae",
"GammaCaeli", "GammaCassiopeiae", "GammaCorvi", "GammaCrucis", "GammaDraconis", "GammaHydrae", "GammaLeonis", "GammaLeporis", "GammaLibrae",
"GammaOrionis", "GammaPavonis", "GammaSagittae", "GammaSculptoris", "GammaSerpentis", "GammaTrianguliAustralis", "GarnetStar", "Gemini", "Giclas3",
"Gienah", "Girtab", "Gliese229B", "GlobularCluster", "Gomeisa", "GorgoneaQuartet", "Grafias", "GrandDesignSpiral", "Grus", "GuardianofEden", "GumNebula", "GwathmeysCluster",
"Gyrus", "Haas21", "Hadar", "HaiweeReservoir", "Halo", "HarringtonSTARSS", "HatNebula", "HawkingsObject", "HeartNebula", "HelixNebula", "Hen31475", "Henize206",
"Henize70", "HerbigHaro", "Hercules", "HerschelsGarnetStar", "HerschelsLittleGlobularCluster", "HicksonCompactGroup", "HicksonGroup", "Himalia", "HIP13044", "HIP13044b",
"HIP13044c", "HIP13044d", "HIP13044e", "HIP13044f", "Hippocamp", "HoardsObject", "HockeyStickGalaxy", "HomunculusNebula", "HoraTertius", "Horologium", "Hyades", "Hydra", "Hydrus", "Hyperion",
"HypotheticalPlanets", "IC1101", "IC1613", "IC1805", "IC1848", "IC2118", "IC2149", "IC2177", "IC418", "IC434", "IC4406", "IC443", "IC4665", "IC4703", "IC5146", "IC5247", "IC5273", "IC5325",
"IC5376", "IC5385", "IC546", "RaptorsNest", "Rareenium", "Rastaban", "RCW49", "RedDwarf", "RedRectangle", "Regor", "RhoCassiopeiae", "RhoCorvi", "RigelKentaurus", "RingNebula", "RiversideGlobularCluster", "RobertsQuartet", "RockyPlanets",
"RosetteNebula", "RoyalGuardianofthePole", "Ruchbah", "RWAsBorealis", "RWAsCephei", "RWAsCygni", "RWAsFornacis", "RWAsGeminorum", "RWAsLacertae", "RWAsPersei", "RWAsScorpii", "RWAsTauri", "Sadr", "Sagittarius", "SagittariusA",
"SagittariusB2", "SagittariusDwarfEllipticalGalaxy", "SagittariusDwarfIrregularGalaxy", "SagittariusDwarfSpheroidalGalaxy", "Saiph", "SakuraisObject", "Sculptor", "SculptorDwarfGalaxy"

    };
}
