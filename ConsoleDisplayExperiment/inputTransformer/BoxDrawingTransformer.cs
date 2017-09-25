using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDisplayExperiment.inputTransformer
{
    public class BoxDrawingTransformer
    {
        public string[] Transform(string[] input)
        {
            //make array of arrays
            char[][] inputBuffer = new char[input.Length][];
            for(int i = 0; i < input.Length; i++)
            {
                inputBuffer[i] = input[i].ToCharArray();
            }


            string[] output = new string[input.Length];
            for(int row = 0; row < input.Length; row++)
            {
                var sb = new StringBuilder();
                for(int col = 0; col < input[row].Length; col++)
                {
                    //if character isn't a wall, skip
                    if(inputBuffer[row][col] != '#')
                    {
                        sb.Append(' ');
                        continue;
                    }

                    //create signature to apply rules
                    string signature = GetSignature(row, col, inputBuffer);

                    //edge cases
                    switch (signature)
                    {
                        // vertical
                        //  |###| |###| |###| | ##| |## | |###| |## | | ##|
                        //  |## | | ##| | ##| | ##| |## | |## | |## | | ##|
                        //  |###| |###| | ##| |###| |###| |## | |## | | ##|
                        case "##### ###":
                        case "### #####":
                        case "### ## ##":
                        case " ## #####":
                        case "## ## ###":
                        case "##### ## ":
                        case " ## ## ##":
                        case "## ## ## ":
                            sb.Append('║');
                            continue;
                        // horizontal
                        //  |###| |# #|  |###| |  #|  |###| |#  | |   | |###|
                        //  |###| |###|  |###| |###|  |###| |###| |###| |###|
                        //  |# #| |###|  |  #| |###|  |#  | |###| |###| |   |
                        case "####### #":
                        case "# #######":
                        case "######  #":
                        case "  #######":
                        case "#######  ":
                        case "#  ######":
                        case "   ######":
                        case "######   ":
                            sb.Append('═');
                            continue;
                        // top left
                        //  |###|                        
                        //  |###|
                        //  |## |
                        case "######## ":
                            sb.Append('╔');
                            continue;
                        // top right
                        //  |###| 
                        //  |###| 
                        //  | ##| 
                        case "###### ##":
                            sb.Append('╗');
                            continue;
                        // bottom left
                        //  |## |
                        //  |###|
                        //  |###|
                        case "## ######":
                            sb.Append('╚');
                            continue;
                        // bottom right
                        //  | ##|     
                        //  |###|     
                        //  |###|     
                        case " ########":
                            sb.Append('╝');
                            continue;
                        // vertical right tee
                        //  |## |                        
                        //  |###|
                        //  |## |
                        case "## ##### ":
                            sb.Append('╠');
                            continue;
                        // vertical left tee
                        //  | ##|                        
                        //  |###|
                        //  | ##|
                        case " ##### ##":
                            sb.Append('╣');
                            continue;
                        // horizontal down tee
                        //  |###|                        
                        //  |###|
                        //  | # |
                        case "###### # ":
                            sb.Append('╦');
                            continue;
                        // horizontal up tee
                        //  | # |                        
                        //  |###|
                        //  |###|
                        case " # ######":
                            sb.Append('╩');
                            continue;
                        //  cross           
                        //  | # |  |## |  | ##|  | # |  | # |  | ##|  |## |                     
                        //  |###|  |###|  |###|  |###|  |###|  |###|  |###|
                        //  | # |  | # |  | # |  |## |  | ##|  |## |  | ##|
                        case " # ### # ":
                        case "## ### # ":
                        case " ##### # ":
                        case " # ##### ":
                        case " # ### ##":
                        case " ####### ":
                        case "## ### ##":
                            sb.Append('╬');
                            continue;
                        default:
                            break;
                    }


                    //catch main cases first
                    //horizontal
                    if (signature[1] == ' ' && signature[7] == ' ')
                    {
                        sb.Append('═');
                        continue;
                    }

                    //vertical
                    if (signature[3] == ' ' && signature[5] == ' ')
                    {
                        sb.Append('║');
                        continue;
                    }

                    //top-left corner or vertical-right tee
                    //  |X?X|
                    //  | ##|
                    //  |X#X|
                    if (signature[3] == ' ' && signature[5] == '#' && signature[7] == '#')
                    {
                        if(signature[1] == ' ')
                        {
                            sb.Append('╔');
                        } else
                        {
                            sb.Append('╠');
                        }
                        
                        continue;
                    }

                    //top-right corner or horizontal down tee
                    //  |X X|
                    //  |##?|
                    //  |X#X|
                    if (signature[3] == '#' && signature[1] == ' ' && signature[7] == '#')
                    {
                        if(signature[5] == ' ')
                        {
                            sb.Append('╗');
                        } else
                        {
                            sb.Append('╦');
                        }
                        continue;
                    }

                    //bottom-left corner or horizontal up tee
                    //  |X#X|
                    //  |?##|
                    //  |X X|
                    if (signature[1] == '#' && signature[5] == '#' && signature[7] == ' ')
                    {
                        if (signature[3] == ' ')
                        {
                            sb.Append('╚');
                        }
                        else
                        {
                            sb.Append('╩');
                        }
                        continue;
                    }

                    //botton-right corner  or vertical-left tee
                    //  |X#X|
                    //  |## |
                    //  |X?X|
                    if (signature[1] == '#' && signature[3] == '#' && signature[5] == ' ')
                    {
                        if (signature[7] == ' ')
                        {
                            sb.Append('╝');
                        }
                        else
                        {
                            sb.Append('╣');
                        }
                        continue;
                    }

                    //if nothing else has gone, just append a space
                    sb.Append(' ');

                }
                output[row] = sb.ToString();
            }
            return output;
        }

        private string GetSignature(int row, int col, char[][] buffer)
        {
            var sb = new StringBuilder(9);
            for(int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if(SafeGet(row + i, col + j, buffer) == '#')
                    {
                        sb.Append('#');
                    } else
                    {
                        sb.Append(' ');
                    }
                }
            }

            return sb.ToString();
        }

        private char SafeGet(int row, int col, char[][] buffer)
        {
            if (row < 0 || col < 0 || row >= buffer.Length || col >= buffer[row].Length)
                return ' ';
            else
                return buffer[row][col];
        }
    }
}
