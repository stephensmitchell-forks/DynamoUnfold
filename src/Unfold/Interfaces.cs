﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unfold;
using Autodesk.DesignScript.Geometry;
using Autodesk.DesignScript.Interfaces;
using Autodesk.DesignScript.Runtime;

namespace Unfold.Interfaces
{
    
        // this class is a comparator that we feed to the constructor of any dictionaries 
        // we want to use these equals and hashcode methods
        // this is done so we do not need to override the equals and hashcode methods on the orignal objects
      [SupressImportIntoVM]
        public class SpatialEqualityComparer<S> : IEqualityComparer<S> where S:ISpatiallyEquatable
        {

            public bool Equals(S x, S y)
            {

                return x.SpatialEquals(y);

            }

            public int GetHashCode(S spatial)
            {
                return spatial.GetSpatialHashCode();
            }
        }

        // this interface forces objects to implement the spatial equals + hashcode methods that the comparator asks for
        public interface ISpatiallyEquatable
        {
            int GetSpatialHashCode();

            bool SpatialEquals(ISpatiallyEquatable y);

        }

     [SupressImportIntoVM]
       public interface IUnfoldablePlanarFace<K> where K:IUnfoldableEdge 
        {
             Object OriginalEntity { get; set; }
             List<Surface> SurfaceEntities { get; set; }
             List<K> EdgeLikeEntities { get; set; }
              int ID { get; set; }
              List<int> IDS { get; set; }
           
        
        }
     [SupressImportIntoVM]
      public  interface IUnfoldableEdge : ISpatiallyEquatable
        {
            Point Start { get; set; }
            Point End { get; set; }
            Curve Curve { get; set; }

        }

    }

