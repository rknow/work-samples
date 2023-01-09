/// <reference path="angular.min.js" />

///-----------------------------------------------------------------
///   File:          Script.js
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Description     Script with angular module, controller and method calls
///-----------------------------------------------------------------

var myApp = angular.module("myModule", []);

var myController = function ($scope, $http, $log) {
    $scope.message = "Angular Students Grid";
    $scope.errMessage = "";
    $scope.studentUrl = 'api/Students';
    $scope.successMessage = "";
    

    var successCallback = function (response) {
        $scope.students = response.data;
        $scope.successMessage = "successfully added";
        $log.info(response);
    };
    var successPostback = function (response) {
        $scope.errMessage = "";
        $scope.successMessage = "successfully added";
    }
    var errorCallback = function (reason) {
        $scope.error = reason.data;
        $log.info(reason);
    };

    var postStudentInfo = function(studentsInfo)
    {
        $http({
            method: 'POST',
            url: $scope.studentUrl,
            data: studentsInfo,
            timeout: 4000
            
        }).then(successPostback, errorCallback);
    }

    $scope.postStudents = function(firstname, lastname, dateOfBirth, gpa, id)
    {
        $scope.errMessage = "";
        $scope.successMessage = "";
        var grade = parseFloat(gpa);
        var dobs = dateOfBirth ? dateOfBirth.split('-') : dobs;
        var dob0 = parseInt(dobs[0]);
        var dob1 = parseInt(dobs[1]);
        var dob2 = parseInt(dobs[2]);
        var sid = id ? parseInt(id) : 0;

        if (dobs.length != 3 || parseInt(dobs[0]) < 1000 ||
            isNaN(parseInt(dobs[0])) || isNaN(parseInt(dobs[1])) || isNaN(parseInt(dobs[2]))
            || dob1 < 1 || dob1 > 12 || dob2 < 1 || dob2 > 31 )
        {
            $scope.errMessage += "Date of birth should be in this format YYYY-MM-DD ";
            return;
        }
        if (parseFloat(gpa) < 0 || parseFloat(gpa) > 4.0 || isNaN(parseFloat(gpa)))
        {
            $scope.errMessage += "GPA cannot be less 0 or greater than 4.0 -- it must be numeric float";
            return;
        }
        if(firstname && lastname)
        {
            var studentInfo = {
                Firstname: firstname,
                Lastname: lastname,
                DateOfBirth: dateOfBirth,
                GPA: parseFloat(gpa),
                ID: sid
            };
            postStudentInfo(studentInfo);
        }
    }

    if ($scope.getS == "true")
    {
        $http({
            method: 'GET', url: 'api/Students'
        }).then(successCallback, errorCallback);
    }
  
};

myApp.controller("myController", myController);

