# Changelog
All notable changes to this package will be documented in this file. The format is based on [Keep a Changelog](http://keepachangelog.com/en/1.0.0/)

## [1.0.0] - 2022-05-21
- Package released

## [1.1.0] - 2022-07-28
- Fixed split screen to work correctly in unity 2021 hdrp
- Changed split screen to work from 2019

## [1.2.0] - 2022-07-31
- Added ISplitScreenVoronoi that allows modifying voronoi directly
- Deprecated ISplitScreenBalancing use ISplitScreenVoronoi 
- Fixed convex polygon GetCentroid return correctly in case area is zero