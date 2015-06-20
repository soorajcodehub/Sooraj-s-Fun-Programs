//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;

//namespace FunPrograms
//{
//    public class GraphOperations
//    {
//        MazeNode[][] mazeStructure; 
//        ArrayList mazeNodesList; 
//        int numberOfNodesVisited;
		


//        private ArrayList getAdjascentNodes(MazeNode n)
//        {
//            ArrayList mazeNodesList = new ArrayList();
//            for(int i = 0 ;i < 10; i ++ )
//            {
//                for(int j=0;j<10;j++)
//                {
					
//                    if(mazeStructure[i][j] == n)
//                    {
//                        if(i+1 < 10 && i-1 >= 0 && j+1 < 10 && j-1 >= 0)
//                        {
//                            if(!mazeStructure[i+1][j].visited)
//                            mazeNodesList.Add(mazeStructure[i+1][j]);
//                            if(!mazeStructure[i][j+1].visited)
//                            mazeNodesList.Add(mazeStructure[i][j+1]);
//                            if(!mazeStructure[i-1][j].visited)
//                            mazeNodesList.Add(mazeStructure[i-1][j]);
//                            if(!mazeStructure[i][j-1].visited)
//                            mazeNodesList.Add(mazeStructure[i][j-1]);
//                        }
//                    }
//                }
//            }
//            return mazeNodesList;
//        }

					
				
//        public 	void getCoordinate(MazeNode n)
//        {
			
//            for(int i = 0 ;i < 10; i ++ )
//            {
//                for(int j=0;j<10;j++)
//                {
					
//                    if(mazeStructure[i][j] == n)
//                    {
//                        n.x = i;
//                        n.y = j;
//                    }
//                }
//            }
//        }


//        public void CreateMaze()
//        {
//            mazeStructure = new MazeNode[10][]; 
//            mazeNodesList = new ArrayList();
//            Random rnd = new Random();
//            MazeNode currentCell = mazeStructure[0][0];
//            MazeNode randomCell; 
//            currentCell.visited = true;
//            while(numberOfNodesVisited < 100)
//            {
//                mazeNodesList = getAdjascentNodes(currentCell);
//                if(mazeNodesList.Count != 0)
//                {
//                    randomCell = (MazeNode)mazeNodesList[rnd.Next(0,3)];
//                    randomCell.visited = true;
//                }	
//            }
				

//        }

//        public void DissolveWall(MazeNode currentCell, MazeNode randomCell)
//        {
//            //dissove walls
//        }
		
//    }

//     class MazeNode{
//    public fixed int walls[4]; 
//    public bool visited;
//    public int x;
//    public int y;
//    }


//}
