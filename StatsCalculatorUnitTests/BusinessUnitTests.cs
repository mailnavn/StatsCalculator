using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatsCalculator.BusinessLayer;
using StatsCalculator.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StatsCalculatorUnitTests
{
    [TestClass]
    public class BusinessUnitTests
    {
        [TestInitialize]
        public void Initialize()
        {
            _Data = new List<double> { 1.357055324, 91.61421247, 15.85347463, 78.44536547, 20.15793072, 67.87355683, 39.12873487, 83.8166761, 8.509336082, 94.33034055, 40.54309044, 66.22646075, 84.4909446, 91.0710246, 40.09800701, 70.05968505, 43.26247358, 64.61889765, 17.73958455, 28.37690378, 19.34305913, 32.07991895, 64.68500554, 26.43928486, 54.85208413, 91.99701255, 56.99163463, 56.2798247, 56.10709823, 92.98291562, 64.25459725, 47.43549882, 36.20623804, 42.50220588, 16.70408316, 94.76653971, 46.12179688, 30.2347051, 8.99448015, 39.48121635, 30.18999886, 98.44696198, 28.75619282, 59.83708016, 64.00887117, 47.66949633, 52.55556241, 56.95280303, 12.82890021, 79.20512652, 52.85935005, 28.36945104, 84.99663117, 68.64248357, 64.3082416, 23.5388214, 98.9646798, 97.70740574, 84.07897327, 68.57378905, 27.41395733, 60.68731889, 96.18366076, 78.38034883, 7.387603392, 27.45705239, 27.93424546, 95.87103723, 79.59882605, 38.1151533, 92.05901083, 46.13854005, 17.18100229, 51.26758939, 75.64054075, 75.62515054, 20.02343625, 15.25662195, 22.82152017, 19.55775611, 2.885790158, 97.96579903, 33.67728513, 30.71114922, 45.47102632, 73.19993931, 48.88965071, 54.61043338, 19.99362943, 41.47048003, 34.92268677, 66.4262891, 86.33832563, 49.86601444, 57.12002083, 58.50436627, 60.00627946, 69.09861592, 23.82311879, 10.07448217, 67.82690211, 48.35129677, 23.39304258, 68.48054741, 88.09785737, 59.06809114, 63.40033014, 5.851423655, 45.3147596, 9.143972137, 47.09854425, 42.90025985, 64.16622627, 22.29651029, 25.24920791, 52.06219652, 55.58800442, 55.37226965, 65.64078539, 10.88591379, 3.056194212, 37.53595928, 61.8609712, 53.41547063, 53.24620564, 42.87500329, 28.1414547, 13.31397151, 56.19587725, 96.42245381, 62.61620354, 76.77118115, 79.18516162, 5.343568692, 52.69949184, 14.06886341, 62.31496811, 91.69297546, 67.00125714, 8.825865284, 10.60564272, 67.79686579, 49.32708575, 59.56812591, 17.76082404, 82.28908675, 9.109545123, 37.23527378, 35.53359069, 70.69188759, 79.88458703, 74.77450568, 25.63527687, 21.39250516, 34.06151806, 85.48547812, 49.99384248, 71.8870346, 83.99321311, 91.76782789, 72.87110934, 35.98586552, 97.88859455, 58.68576142, 88.51163618, 13.40125094, 17.74275001, 10, 87.69990166, 93.36646538, 82.45813939, 39.93384036, 18.46758355, 98.16648986, 33.24882402, 80.23347151, 98.8322255, 24.96859081, 31.52748239, 47.26463054, 58.10221606, 53.60944534, 21.4514635, 74.06483102, 61.39244853, 25.3702833, 76.89185742, 4.09686213, 48.50183929, 60.05465027, 77.93336134, 12.04178082, 67.48349785, 89.45265935, 43.44056563, 12.30490738, 60.17124981, 12.07040442, 37.57267329, 85.6357515, 6.33016056, 5.044884704, 87.43887663, 75.87880074, 74.75456592, 66.00755219, 85.87283865, 96.82514877, 60.77941825, 25.00022124, 58.51525982, 9.74188032, 24.12664128, 73.0510104, 15.03510112, 9.327265384, 85.26965892, 31.18505865, 66.03620425, 90.20357046, 2.144269231, 20, 66.2573165, 58.71613132, 2.273816678, 82.16058798, 69.768357, 76.57250163, 30.96821611, 92.9711853, 37.65336766, 79.91787829, 33.62815258, 66.8641081, 68.48642463, 88.82108609, 79.20969657, 1.561693816, 16.79724366, 35.09942222, 96.86159324, 85.41518197, 1.30320322, 53.19104232, 86.26892235, 3.02427008, 91.8141196, 62.09870644, 22.52777393, 79.91020585, 67.42339663, 26.44169555, 52.13705374, 50.41193161, 74.49911372, 6.517346448, 89.65630518, 63.52261731, 16.0943132, 68.63250879, 12.07393836, 4.229903882, 23.34461318, 71.35121348, 21.70976558, 90.478251, 17.79539294, 50.48662207, 24.05890969, 35.51752042, 91.72430166, 63.58224829, 10.90977989, 15.78608415, 88.65049469, 64.06880889, 93.70097263, 19.08494297, 7.343993222, 74.39559589, 0.943834102, 25.87075862, 85.49855691, 53.25925988, 54.3779639, 15.59991109, 70.78572724, 0.424488296, 15.88460543, 72.59473932, 41.77668283, 32.67005715, 46.04183957, 20.87263317, 31.39682769, 8.81854535, 84.094971, 45.97230777, 70.00558925, 42.17364256, 57.51283276, 44.00623434, 5.485825805, 67.82373486, 31.21531261, 45.44835268, 65.65069449, 66.16650485, 69.84332124, 42.31295815, 24.38795586, 95.31411672, 83.41287545, 70.95619959, 67.14642461, 95.30998303, 69.79972877, 82.11561136, 16.00866958, 71.33754237, 45.1805748, 32.88940131, 53.71073498, 20.14839319, 67.54458181, 74.54259111, 50.39912911, 93.29279319, 79.70223097, 28.8805243, 69.52959251, 89.88033536, 74.44079627, 19.43343125, 36.79139759, 21.48319517, 21.22526148, 26.76030468, 60.58090202, 40.19887572, 77.71144557, 82.63128416, 76.4980902, 93.26233715, 27.470956, 63.98905261, 43.97651227, 85.56892895, 19.46505443, 14.87719462, 50.11169599, 76.38751744, 99.79455157, 68.22110162, 91.45904027, 17.84425888, 12.76999863, 52.12872535, 19.74708847, 23.52507506, 60.85381744, 28.66250795, 23.89228502, 84.7973941, 8.865468783, 25.9485465, 13.50186977, 90.60053426, 58.59598309, 47.70261856, 77.27957192, 91.86546986, 43.93930673, 70.43670468, 94.40019319, 51.06305746, 64.52794307, 90.77554314, 33.679907, 55.61455573, 99.00295177, 53.9456124, 58.16203494, 56.41621328, 63.48012744, 9.421496951, 2.948366573, 31.33651662, 90.8028278, 96.29375464, 77.52564696, 12.68842113, 20.51502836, 64.1542828, 80.63279331, 69.21866798, 14.61418745, 15.26664239, 45.29052757, 42.98198591, 31.57198351, 72.38109716, 28.61935347, 37.88837155, 12.66483675, 8.094748167, 49.88718459, 51.29046392, 38.78971958, 32.26857284, 59.16767175, 30.00221389, 1.445302074, 92.97331656, 47.19696242, 20.85782655, 38.18027089, 12.47971851, 2.750970009, 75.41597394, 48.42380336, 14.24130517, 54.38121901, 96.51843987, 85.66172602, 80.67743344, 84.30729767, 23.82023581, 34.84854543, 2.023321979, 10.67070616, 59.63236797, 20.68698104, 75.36995472, 27.53348333, 65.85876206, 97.65600242, 39.40121337, 26.54003998, 62.14009388, 83.85763606, 0.223439887, 83.23903232, 90.58492941, 9.942171618, 42.45792855, 40.69223525, 56.84924907, 88.76706999, 56.09837186, 27.29211569, 81.49044269, 59.93729899, 89.44496871, 80.05258439, 78.23919089, 25.73798922, 19.0482187, 75.41629762, 97.89963136, 52.79081563, 54.00349338, 41.57785543, 43.48958691, 80.03963494, 48.33841518, 21.45953564, 20.73730842, 72.56580675, 37.96137043, 80.25528892, 87.05693601, 24.23156231, 48.36913714, 83.72134871, 58.28951615, 32.38485743, 69.98025904, 3.228272926, 91.36632047, 21.05752767, 21.88990391, 91.60573343, 54.46258232, 85.75755444, 15.44289893, 16.44600315, 85.70896524, 91.03088616, 43.82963446, 79.04162859, 91.6078524, 47.79563685, 36.77782534, 5.707097119, 85.54688604, 25.09490389, 21.38628055, 26.61405335, 95.26598065, 70.9588274, 51.52143946, 98.08843317, 82.26045646, 18.17614728, 27.76475665, 34.83873962, 20.54796367, 89.61027318, 99.91116759, 94.26378681, 49.17968743, 79.18339313, 37.64435867, 54.69770683, 35.41588991, 94.1656033, 61.36100993, 89.72723593, 93.07627909, 64.68128899, 87.34727898, 85.63274419, 70.10704565, 91.69262943, 5.720873266, 63.72475452, 86.50735531, 61.38770177, 75.1844263, 11.27938795, 28.22645422, 84.55540743, 75.71594253, 30.3642333, 77.58568715, 1.926088588, 88.12960127, 59.76786809, 41.48607225, 4.706170249, 39.19898536, 37.6042871, 0.26195405, 67.85516675, 85.52950706, 51.33339208, 83.11780778, 37.99922759, 66.83586214, 47.38787564, 16.10442995, 75.55000003, 45.82478142, 60.68646956, 82.60625433, 56.36708222, 5.89436935, 85.9530431, 21.65788504, 8.043472525, 33.50659856, 36.10306129, 57.32057125, 78.27359953, 38.88983575, 81.48656594, 23.96951035, 36.18133961, 31.31666912, 96.71587082, 48.05990819, 5.126047526, 27.07070901, 7.559773429, 38.9475599, 48.01296215, 8.167097424, 60.66263804, 95.91485159, 58.4031955, 73.70107238, 43.78577972, 20.11989581, 68.92619128, 22.00976634, 29.26907271, 66.91080029, 86.6386432, 2.854411158, 70.78464726, 16.66053385, 48.29258991, 62.78715192, 49.5160012, 95.01423536, 52.45306394, 79.14498631, 48.41601548, 69.14673201, 81.19105817, 31.84600162, 5.755674929, 91.57515682, 90.09536653, 12.10323166, 55.09831409, 7.449864706, 6.61154559, 5.592972803, 17.309695, 72.88934541, 71.07207445, 33.25366601, 13.23695239, 11.12663427, 48.18887957, 55.41773127, 24.09470332, 9.917005649, 86.87477422, 89.77334392, 33.83537036, 38.11975704, 80.1942336, 53.89209035, 14.78655637, 19.80747314, 48.33003452, 5.202493547, 57.02203968, 23.85490087, 72.80736258, 34.57539243, 33.22198784, 11.36019085, 94.96893237, 7.687310749, 30.0024718, 79.58318284, 15.05806272, 23.30092062, 96.6469582, 39.15610725, 53.99005667, 92.93924813, 71.98779562, 17.87270687, 43.85687375, 35.8903748, 79.98949671, 49.54209669, 49.57048781, 9.479989982, 69.72087927, 17.95323625, 69.28060721, 51.63385066, 22.50091986, 11.14780284, 60.55894092, 0.508422941, 30.8579623, 97.83354069, 75.00025485, 52.57364027, 82.57800486, 89.33472174, 30.76168202, 18.80642457, 28.56659819, 82.02579221, 62.53348023, 45.7938187, 10.25794063, 57.28038015, 68.27791802, 53.01708226, 1.616863135, 81.56739648, 66.70605771, 50.32188536, 5.045164245, 28.69813254, 90.47896749, 26.03924568, 92.52566587, 95.34857616, 46.65421173, 14.42211912, 51.96657026, 22.07011778, 12.09198945, 64.74853068, 36.41413117, 14.54991293, 36.3991201, 50.77512716, 50.92377664, 96.06762082, 71.11937634, 47.79215203, 35.36896294, 75.06133034, 43.19510639, 27.83483665, 51.91472376, 79.97255948, 74.41389494, 37.10672711, 56.11569464, 21.05971051, 88.14603639, 52.1847043, 74.24312099, 60.32136442, 42.90673631, 13.36738991, 42.92315071, 67.72027882, 3.549873426, 60.15204657, 36.48287247, 79.6538216, 82.68253527, 79.27483707, 25.61467298, 74.07908663, 59.66443196, 69.03969857, 41.46827881, 95.32947624, 73.84624993, 67.14469125, 92.20933153, 16.83380922, 5.313404749, 93.91180606, 78.45848387, 34.02837948, 46.37180504, 77.7788573, 19.72567505, 28.23487052, 49.37125387, 63.23147813, 39.20428629, 10.57384137, 85.93803111, 4.11824097, 62.4062921, 2.816905074, 94.29503293, 90.05466134, 48.86451038, 52.02469939, 87.86218677, 14.98651496, 40.91505081, 64.09049774, 97.35064015, 79.32408949, 6.799322613, 39.02062708, 56.98683231, 38.51732553, 93.36184726, 69.16419171, 69.22663294, 19.13192241, 10.28056902, 76.15985037, 16.46693366, 81.77035559, 28.14739751, 43.44756293, 13.10251164, 28.65323317, 7.349563253, 43.92116894, 1.452692211, 0.77251774, 52.30102309, 2.0473128, 91.97737421, 9.496666145, 1.140317565, 8.29318649, 77.29105154, 69.9497557, 59.32804067, 78.14151473, 48.30139226, 34.37855026, 76.23602009, 99.5555678, 3.069368773, 56.74815681, 54.29416147, 29.70108234, 97.58743124, 23.95346972, 18.86379023, 73.10537166, 0.411783, 27.58799997, 10.32146851, 98.169406, 53.81326521, 54.11227566, 92.46493159, 23.04313129, 84.13707817, 72.86708283, 47.1653528, 34.95168879, 84.75393967, 61.85040205, 86.87032176, 23.23318786, 20.94595978, 15.8443531, 64.90694978, 71.0708785, 18.34592768, 15.56960852, 44.97030466, 68.67057955, 70.25415895, 56.43465347, 89.6312679, 24.28410055, 67.77437543, 62.39607744, 56.00245399, 26.23197162, 96.30469925, 61.36715146, 98.27492243, 20.44063456, 2.534679001, 6.039757827, 0.282312519, 96.95065049, 11.25433418, 89.73067028, 89.22863895, 45.89828665, 43.62360995, 68.65872186, 0.529876225, 21.93247698, 2.581470895, 36.98719984, 13.06072177, 26.40550725, 85.74174783, 59.81821404, 42.68031621, 33.35735519, 9.148156498, 4.720659717, 6.324426388, 47.31504559, 92.4380129, 67.06048888, 10.68312212, 83.54361186, 56.17724672, 33.27950577, 83.09691387, 50.33308729, 99.64721468, 38.75526319, 8.321763171, 16.09985062, 75.28305726, 44.73570298, 26.92145555, 44.16252199, 89.69616314, 9.427193201, 19.21877348, 60.51548854, 61.92894504, 9.2137998, 11.88634844, 6.493230848, 99.74419773, 54.38381409, 74.57311823, 13.57409629, 14.50272327, 18.91560687, 66.18947771, 86.80481057, 61.36911379, 30.42678661, 45.59516375, 79.41806367, 35.22250675, 45.12997254, 61.88909016, 92.05922925, 99.5125749, 67.09618167, 79.49476821, 38.91409083, 87.46500661, 0.194364624, 95.22916696, 49.78657869, 19.60160816, 9.459100284, 0.464610594, 87.37043282, 15.71271159, 37.17893741, 71.78729199, 91.61977781, 48.68439414, 26.21560926, 46.4898128, 89.4002143, 18.45845804, 61.18454599, 98.58859642, 58.02866016, 12.464424, 89.32076085, 93.09077408, 48.40992205, 12.20631988, 81.63707828, 42.82328132, 23.49478951, 3.179788599, 9.520079722, 55.78644811, 57.27004798, 74.49555591, 59.30240088, 49.60921114, 10.70332528, 10.1327047, 27.17720842, 83.69917947, 8.471235634, 40.10514466, 71.71207746, 38.35432873, 92.04220835, 34.98010229, 40.55733258, 13.08173995, 93.68272443, 72.89884917, 62.20888467, 64.82183046, 54.86223798, 13.66634131, 53.07523684, 16.23765517, 82.51562283, 73.89619415, 47.70258092, 14.64535959, 39.87620652, 36.91659482, 30.21064435, 85.71833358, 88.91349043, 68.81514491, 27.81141828, 71.61064703, 74.07401725, 84.61313562, 39.9125462, 11.67301517, 23.82417512, 76.15888364, 18.91630005, 66.73733295, 41.19505821, 75.22122217, 83.9491024, 97.46694698, 57.26068833, 91.67205925, 53.76875053, 66.20425622, 4.996072792, 84.04481142, 89.49840285, 30.66769355, 10.28337152, 32.82544451, 5.950546868, 93.48248845, 71.28272465 };
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test number when length of numbers are even
        /// </summary>
        [TestMethod]
        public void TestAddSumMethodEvenNumberLength()
        {
            var numbers = new List<double> { 23.234, 234.348657, 234.465, 0, 2342.234, 234242.2342 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateSum(numbers.ToArray());
            Assert.AreEqual(237076.515857, result);
        }

        /// <summary>
        /// Test number when length of numbers are odd
        /// </summary>
        [TestMethod]
        public void TestAddSumMethodOddNumberLength()
        {
            var numbers = new List<double> { 23.234, 234.348657, 234.465, 2342.234, 234242.2342 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateSum(numbers.ToArray());
            Assert.AreEqual(237076.515857, result);
        }

        /// <summary>
        /// Test long list of numbers and rounding off to 10 decimal points
        [TestMethod]
        public void TestAddSumMethodLongList()
        {
            var numbers = _Data;
            StatisticsCalculator cal = new();
            var result = cal.CalculateSum(numbers.ToArray());
            Assert.AreEqual(50344.72412237, result);
        }

        /// <summary>
        /// Test when only one number is contained in the list
        [TestMethod]
        public void TestAddSumWithOnlyOneNumber()
        {
            var numbers = new List<double> { 1.357055324 };
            StatisticsCalculator cal = new();
            var result = cal.CalculateSum(numbers.ToArray());
            Assert.AreEqual(1.357055324, result);
        }


        [TestMethod]
        public void TestSumWithRoundUp()
        {
            // 1.99999999999 = 11 decimal points, 1.0000000001 10 decimal points
            var numbers = new List<double> { 1.99999999999, 1.0000000001 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateSum(numbers.ToArray());

            // Actual result = 3.00000000009 (11 decimal points), Round up value = 3.0000000001
            Assert.AreEqual(3.0000000001, result);
        }

        [TestMethod]
        public void TestCalculateArithmeticMean()
        {
            var numbers = new List<double> { 10.134234234342, 20.1223424, 30.34, 34.34343, 34.23423424234 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateArithmeticMean(numbers.ToArray());

            Assert.AreEqual(25.83484817534, result);
        }


        [TestMethod]
        public void TestCalculateArithmeticMeanNegativeNumbers()
        {
            var numbers = new List<double> { 10.134234234342, -20.1223424, 30.34, -34.34343, 34.23423424234 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateArithmeticMean(numbers.ToArray());

            Assert.AreEqual(4.04853921534, result);
        }


        [TestMethod]
        public void TestCalculateArithmeticMeanEmptyorNull()
        {
            var numbers = new List<double> { };
            StatisticsCalculator cal = new StatisticsCalculator();

            // Verify that expected exception 
            Assert.ThrowsException<ApiException>(() => { cal.CalculateArithmeticMean(numbers.ToArray()); }, "Values cannot be empty");
        }


        [TestMethod]
        public void TestCalculateSampleStandardDeviation()
        {
            var numbers = new List<double> { 2, 4, 3, 2, 1 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateStandardDeviation(numbers.ToArray(), SDType.Sample);
            Assert.AreEqual(1.1401754251, result);
        }


        [TestMethod]
        public void TestCalculatePopulationStandardDeviation()
        {
            var numbers = new List<double> { 2, 4, 3, 2, 1 };
            StatisticsCalculator cal = new StatisticsCalculator();
            var result = cal.CalculateStandardDeviation(numbers.ToArray(), SDType.Population);
            Assert.AreEqual(1.0198039027, result);
        }


        [TestMethod]
        public void TestHistogramAndFrequencyOfNumbers()
        {
            var numbers = new List<double> { 0.001, 10.123, 10, 20.34, 20, 30.00001, 40.0001 };
            StatisticsCalculator cal = new StatisticsCalculator();

            var result = cal.GetHistogramAndFrequency(numbers.ToArray(), 10);

            Assert.AreEqual(5, result.Keys.Count);

            // Verify for 0 to <10
            var resultLT10 = result[1];
            Assert.AreEqual(1, resultLT10.Item1.Count);

            // Verify for 10 to <20
            var resultLT20GT10 = result[2];
            Assert.AreEqual(2, resultLT20GT10.Item2);
            Assert.IsTrue(resultLT20GT10.Item1.Contains(10));
            Assert.IsTrue(resultLT20GT10.Item1.Contains(10.123));

            // Verify for 20 to <30
            var resultLT30GT20 = result[3];
            Assert.AreEqual(2, resultLT30GT20.Item2);
            Assert.IsTrue(resultLT30GT20.Item1.Contains(20));
            Assert.IsTrue(resultLT30GT20.Item1.Contains(20.34));

        }

        #region private properties
        List<double> _Data { get; set; }
        #endregion
    }
}
