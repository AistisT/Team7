<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditForm.aspx.cs" Inherits="Group7.EditForm" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="row" id="formValidator">
        <div class="col-sm-6">
            <div class="form-group" id="vacancyTitleGroup">
                <label for="inputTitle" class="col-sm-5 control-label">Vacancy title  <b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputTitle" placeholder="Vacancy title"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="positionGroup">
                <label for="inputPosition" class="col-sm-5 control-label">Employee position</label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputPosition" placeholder="Software Engineer, etc..."></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="disciplineGroup">
                <label for="inputDiscipline" class="col-sm-5 control-label">Discipline</label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Business Systems</a></li>
                                <li><a href="#">Network Security</a></li>
                                <li><a href="#">Games Development</a></li>
                                <li><a href="#">Software Development</a></li>
                                <li><a href="#">Web Development</a></li>
                                <li><a href="#">Digital Marketing</a></li>
                                <li><a href="#">Technical Sales</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputDiscipline" placeholder="Job Field/Discipline"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="contractGroup">
                <label for="inputContract" class="col-sm-5 control-label">Contract type <b>*</b></label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Full-time</a></li>
                                <li><a href="#">Part-time</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputContract" placeholder="Full time, Part time"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="hoursGroup">
                <label for="inputHours" class="col-sm-5 control-label">Hours a week</label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">10 to 15 hours a week</a></li>
                                <li><a href="#">15 to 20 hours a week</a></li>
                                <li><a href="#">20 to 30 hours a week</a></li>
                                <li><a href="#">30 to 40 hours a week</a></li>
                                <li><a href="#">40 to 48 hours a week</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputHours" placeholder="Hours a Week"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="salaryGroup">
                <label for="inputSalary" class="col-sm-5 control-label">Salary <b>*</b></label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">£12,000 to £15,000</a></li>
                                <li><a href="#">£15,000 to £20,000</a></li>
                                <li><a href="#">£20,000 to £30,000</a></li>
                                <li><a href="#">£30,000 to £50,000</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputSalary" placeholder="Salary"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="yearGroup">
                <label for="inputYear" class="col-sm-5 control-label">Required student level</label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Third-year</a></li>
                                <li><a href="#">Fourth-year</a></li>
                                <li><a href="#">Graduate</a></li>
                                <li><a href="#">PhD student</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputYear" placeholder="Third year, Fourth year,etc..."></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="closingDateGroup">
                <label for="inputClosingDate" class="col-sm-5 control-label">Closing date <b>*</b></label>
                <div class="col-sm-7">
                    <div class="input-group date" id="calendarPicker">
                        <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                        <asp:TextBox class="form-control" type="text" ID="inputClosingDate" AutoCompleteType="disabled" placeholder="day/month/year" runat="server" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="form-group" id="companyNameGroup">
                <label for="inputCompanyName" class="col-sm-5 control-label">Company name <b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputCompanyName" placeholder="Company Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="sectorGroup">
                <label for="inputSector" class="col-sm-5 control-label">Company sector</label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputSector" placeholder="Company Sector"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="contactNameGroup">
                <label for="inputContactName" class="col-sm-5 control-label">Contact name </label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputContactName" placeholder="Contact Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="contactEmailGroup">
                <label for="inputContactEmail" class="col-sm-5 control-label">Contact email <b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputContactEmail" placeholder="Contact Email"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="contactTelephoneGroup">
                <label for="inputContactNumber" class="col-sm-5 control-label">Contact telephone number <b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputContactNumber" placeholder="Contact Telephone Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="houseGroup">
                <label for="inputHouse" class="col-sm-5 control-label">Address: House number or name</label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputHouse" placeholder="House Number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="streetGroup">
                <label for="inputStreet" class="col-sm-5 control-label">Street name</label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputStreet" placeholder="Street name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="postcodeGroup">
                <label for="inputPostcode" class="col-sm-5 control-label">Postcode</label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputPostcode" placeholder="Postcode"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="townGroup">
                <label for="inputTown" class="col-sm-5 control-label">Town <b>*</b></label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Dundee</a></li>
                                <li><a href="#">Edinburgh</a></li>
                                <li><a href="#">Glasgow</a></li>
                                <li><a href="#">Aberdeen</a></li>
                                <li><a href="#">Perth</a></li>
                                <li><a href="#">Inverness</a></li>
                                <li><a href="#">Stirling</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputTown" placeholder="Town"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group" id="jobValidator">
        <div class="form-group" id="descriptionGroup">
            <label for="inputJobDescription" class="col-sm-2 control-label">Job description <b>*</b></label>
            <div class="col-sm-10">
                <asp:TextBox class="form-control" Wrap="true" TextMode="MultiLine" Rows="5" ID="inputJobDescription" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-sm-6">
            <div class="col-sm-5"></div>
            <div class="col-sm-7">
                <div class="checkbox">
                    <label>
                        <asp:CheckBox runat="server" ID="checkBox" AutoPostBack="True" OnCheckedChanged="checkBox_CheckedChanged" />Add student details
                    </label>
                </div>
            </div>
        </div>
        <div class="col-sm-6"></div>
    </div>

    <div class="row" id="StudentValidator" hidden="hidden" runat="server" clientidmode="Static">
        <br />
        <div class="col-sm-6">
            <div class="form-group" id="StudentMatrGroup">
                <label for="inputStudentMatr" class="col-sm-5 control-label">Matriculation number<b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputStudentMatr" placeholder="Matriculation number"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="StudentFirstNameGroup">
                <label for="inputStudentFirstName" class="col-sm-5 control-label">First name<b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputStudentFirstName" placeholder="First name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group" id="StudentLastNameGroup">
                <label for="inputStudentLastName" class="col-sm-5 control-label">Last name<b>*</b></label>
                <div class="col-sm-7">
                    <asp:TextBox runat="server" type="text" class="form-control" ID="inputStudentLastName" placeholder="Last name"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="form-group" id="StudentCourseGroup">
                <label for="inputStudentCourse" class="col-sm-5 control-label">Course</label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li role="presentation" class="dropdown-header">Undergraduate Courses</li>
                                <li><a href="#">BSc (Honours) Applied Computing</a></li>
                                <li><a href="#">BSc (Honours) Applied Computing (Games)</a></li>
                                <li><a href="#">BSc (Honours) Applied Computing: Human Computer Interaction</a></li>
                                <li><a href="#">BSc (Honours) Computing Science</a></li>
                                <li role="presentation" class="divider"></li>
                                <li role="presentation" class="dropdown-header">Postgraduate Courses</li>
                                <li><a href="#">MSc in Information Technology and International Business</a></li>
                                <li><a href="#">MSc in Computing</a></li>
                                <li><a href="#">MSc in Computing with International Business</a></li>
                                <li><a href="#">MSc in Augmentative and Alternative Communication</a></li>
                                <li><a href="#">MSc in Computing Research</a></li>
                                <li><a href="#">MSc in Data Science</a></li>
                                <li><a href="#">MSc in User Experience Engineering</a></li>
                                <li><a href="#">MSc in Data Engineering</a></li>
                                <li><a href="#">MSc in Reasoning Analytics</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="inputStudentCourse" placeholder="Course name"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group" id="StudentYearGroup">
                <label for="InputStudentYear" class="col-sm-5 control-label">Level</label>
                <div class="col-sm-7">
                    <div class="input-group">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-expanded="false">&thinsp;<span class="caret"></span>&thinsp;</button>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Third-year</a></li>
                                <li><a href="#">Fourth-year</a></li>
                                <li><a href="#">Graduate</a></li>
                                <li><a href="#">PhD student</a></li>
                            </ul>
                        </div>
                        <asp:TextBox runat="server" type="text" class="form-control" ID="InputStudentYear" placeholder="Year student is in"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="form-group">
        <div class="col-sm-10 col-sm-offset-2">
            <h6><b>* Required Fields</b></h6>
            <asp:Button type="button" class="btn btn-default" OnClick="resetExecuted" runat="server" Text="Reset" OnClientClick="return confirm('Are you sure you want to reset all the fields?');"></asp:Button>
            <asp:Button type="button" class="btn btn-default" OnClick="deleteExecuted" Text="Delete" runat="server" OnClientClick="return confirm('Are you sure you want to delete this vacancy?');"></asp:Button>
            <button type="submit" class="btn btn-primary" id="submitButton">Submit</button>
            <%--button asp.net runat sever--%>
            <asp:LinkButton ID="saveButton" CssClass="lbtSubmit btn btn-default" runat="server" OnClick="submitExecuted" Style="display: none" OnClientClick="return confirm('Are you sure you want to submit this vacancy?');">LinkButton</asp:LinkButton>
            <%--message return from sever side--%>
            <asp:Literal ID="ltrMs" runat="server"></asp:Literal>
        </div>
    </div>


    <!-- Various javascripts that are used within this page-->
    <script>   
        // bootstrap datepicker https://github.com/eternicode/bootstrap-datepicker
        /*  Apache License
            Version 2.0, January 2004
            http://www.apache.org/licenses/ */
        $(document).ready(function() {
            $('#calendarPicker').datepicker({
                format: "dd/mm/yyyy",
                //startDate: today,
                weekStart: 1,
                autoclose: true,
                todayHighlight: true
            });
            // end of datepicker

            // calls submit on enter key press while focused on a any textbox in a page
            $('input[type=text]').keypress(function(e) {
                if(e.which == 13) {
                    $("#submitButton").click(); 
                }
            });

            // finding textbox and assigning value from dropdown list to it
            $(document).on('click', '.dropdown-menu li a', function() {
                $(this).parent().parent().parent().parent().find('input[type="text"]').val($(this).html());
                // focusing textbox after item was seletected in dropdown list, makes navigation smoother as it eliminates need to tab from dropdown list to textbox, and fixes chrome bug (reseting focus after using dropdown list)
                $(this).parent().parent().parent().parent().find('input[type="text"]').focus();
                //validing textbox after droplist selection
                $(this).closest('.row').data('bootstrapValidator').revalidateField( $(this).parent().parent().parent().parent().find('input[type="text"]'));  
            }); 

            // revalidating calendar date after using calendar
            $("#calendarPicker").on("changeDate", function(e) {
                $("#formValidator").data('bootstrapValidator').revalidateField("<%= inputClosingDate.UniqueID %>");  
                document.getElementById("inputClosingDate").focus(); 
            });
        });
             
            /*BootstrapValidator is free to use in non-commercial projects under the terms of the Creative 
            Commons BY-NC-ND 3.0 (http://creativecommons.org/licenses/by-nc-nd/3.0/) license.
            If you use BootstrapValidator in commercial projects and products, you must purchase a commercial license.
    
            For more information about the license, see http://bootstrapvalidator.com/license/ */

            // validating first form
            $('#formValidator').bootstrapValidator({
                message: 'This value is not valid',
                submitButtons: 'button[type="submit"]',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                fields: {
                    // variouos fields to validate and parameters on which to validate them
                    <%= inputTitle.UniqueID %>: {
                    message: 'Vacancy title is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Vacancy title  is required and cannot be empty'
                        },
                        stringLength: {
                            min: 6,
                            max: 100,
                            message: 'Vacancy title  must be more than 6 and less than 100 characters long'
                        }
                    }
                },
                <%= inputPosition.UniqueID %>: {
                    message: 'Employee position is not valid',
                    validators: {                              
                        stringLength: {
                            min: 6,
                            max: 50,
                            message: 'Employee position  must be more than 6 and less than 50 characters long'
                        }
                    }
                },
                <%= inputDiscipline.UniqueID %>: {
                    message: 'Job Field/Discipline is not valid',
                    validators: {                              
                        stringLength: {
                            min: 6,
                            max: 50,
                            message: 'Job field/discipline must be more than 6 and less than 50 characters long'
                        },
                        regexp: {
                            regexp: /^[a-z\s]+$/i,
                            message: 'Job field/discipline name can consist of alphabetical characters and spaces only'
                        }
                    }
                },
                <%= inputContract.UniqueID %>: {
                    message: 'Contract is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Contract is required and cannot be empty'
                        },
                        stringLength: {
                            min: 6,
                            max: 50,
                            message: 'Contract must be more than 6 and less than 50 characters long'
                        },
                        regexp: {
                            regexp: /^[a-z\s\-]+$/i,
                            message: 'Contract can consist of alphabetical characters, hyphen and spaces only'
                        }
                    }
                },
                <%= inputHours.UniqueID %>: {
                    message: 'Hours per week is not valid',
                    validators: {                              
                        stringLength: {
                            min: 1,
                            max: 50,
                            message: 'Hours per week must be more than 1 and less than 50 characters long'
                        }
                    }
                },
                <%= inputSalary.UniqueID %>: {
                    message: 'Salary is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Salary is required and cannot be empty'
                        },
                        stringLength: {
                            min: 4,
                            max: 50,
                            message: 'Salary must be more than 4 and less than 50 characters long'
                        }
                    }
                },
                <%= inputYear.UniqueID %>: {
                    message: 'Student level is not valid',
                    validators: {                              
                        stringLength: {
                            min: 1,
                            max: 50,
                            message: 'Student level must be more than 1 and less than 20 characters long'
                        },
                        regexp: {
                            regexp: /^[a-z\s\-]+$/i,
                            message: 'Student level  can consist of alphabetical characters,hyphen and spaces only'
                        }
                    }
                },
                <%= inputClosingDate.UniqueID %>: {
                    message: "Closing date is not valid",
                    validators: {
                        notEmpty: {
                            message: 'Closing date is required and cannot be empty'
                        },
                        date: {
                            format: 'DD/MM/YYYY',
                            message: "Closing date format is not valid, please use DD/MM/YYYY and re-enter closing date",
                        }
                    }
                },
                    
                <%= inputCompanyName.UniqueID %>: {
                    message: 'Company name is not valid',
                    validators: {
                        notEmpty: {
                            message: 'Company is required and cannot be empty'
                        },
                        stringLength: {
                            min: 2,
                            max: 50,
                            message: 'Company must be more than 2 and less than 50 characters long'
                        }
                    }
                },
                <%= inputSector.UniqueID %>: {
                    message: 'Company sector is not valid',
                    validators: {                              
                        stringLength: {
                            min: 4,
                            max: 50,
                            message: 'Company sector must be more than 4 and less than 50 characters long'
                        }
                    }
                },
                <%= inputContactName.UniqueID %>: {
                    message: 'Contact name is not valid',
                    validators: {                              
                        stringLength: {
                            min: 2,
                            max: 50,
                            message: 'Contact name must be more than 2 and less than 50 characters long'
                        },
                        regexp: {
                            regexp: /^[a-z\s]+$/i,
                            message: 'Contact name can consist of alphabetical characters and spaces only'
                        }
                    }
                },
                <%= inputContactEmail.UniqueID %>: {
                    validators: {
                        notEmpty: {
                            message: 'The email is required and cannot be empty'
                        },
                        emailAddress: {
                            message: 'The input is not a valid email address'
                        }
                    }
                },
                <%= inputContactNumber.UniqueID %>: {
                    validators: {
                        message: 'Contact Telephone number is not valid',
                        notEmpty: {
                            message: 'Contact Telephone number is required'
                        },
                        phone: {
                            message: 'Contact Telephone number is not valid',
                            country: 'GB'
                        }
                    }
                },
                <%= inputHouse.UniqueID %>: {
                    message: 'House number is not valid',
                    validators: {                              
                        stringLength: {
                            min: 1,
                            max: 50,
                            message: 'House number must be more than 1 and less than 50 characters long'
                        }
                    }
                },
                <%= inputStreet.UniqueID %>: {
                    message: 'Street name is not valid',
                    validators: {                              
                        stringLength: {
                            min: 3,
                            max: 50,
                            message: 'Street name must be more than 3 and less than 50 characters long'
                        }
                    }
                },
                <%= inputPostcode.UniqueID %>: {
                    message: 'Company sector is not valid',
                    validators: {                              
                        zipCode: {
                            country: 'GB',
                            message: 'The value is not valid post code'
                        }
                    }
                },
                <%= inputTown.UniqueID %>: {
                    message: 'Town name is not valid',
                    validators: {  
                        notEmpty: {
                            message: 'Town name is required'
                        },
                        stringLength: {
                            min: 3,
                            max: 50,
                            message: 'Town name must be more than 3 and less than 50 characters long'
                        },
                        regexp: {
                            regexp: /^[a-z\s]+$/i,
                            message: 'Town name can consist of alphabetical characters and spaces only'
                        }
                    }
                }                                       
            }
        });

        //validating description form
        $('#jobValidator').bootstrapValidator({
            message: 'This value is not valid',
            submitButtons: 'button[type="submit"]',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                <%= inputJobDescription.UniqueID %>: {
                    message: 'Job description is not valid',
                    validators: {  
                        notEmpty: {
                            message: 'Job description is required'
                        },
                        stringLength: {
                            min: 50,
                            max: 4000,
                            message: 'Job description must be more than 50 and less than 4000 characters long'
                        }
                    }
                }   
            }
        });

        // validating student form
        $('#StudentValidator').bootstrapValidator({
            message: 'This value is not valid',
            submitButtons: 'button[type="submit"]',
            feedbackIcons: {
                valid: 'glyphicon glyphicon-ok',
                invalid: 'glyphicon glyphicon-remove',
                validating: 'glyphicon glyphicon-refresh'
            },
            fields: {
                <%= inputStudentMatr.UniqueID %>: {
                        message: 'Student matriculation number is not valid',
                        validators: {  
                            notEmpty: {
                                message: 'Student matriculation number is required'
                            },
                            stringLength: {
                                min: 5,
                                max: 50,
                                message: 'Student matriculation number must be more than 5 and less than 50 characters long'
                            },
                            digits: {
                                message: 'Student matriculation number can contain only digits'
                            }
                        }
                    },
                    <%= inputStudentFirstName.UniqueID %>: {
                        message: 'Student first name is not valid',
                        validators: {  
                            notEmpty: {
                                message: 'Student last name number is required'
                            },
                            stringLength: {
                                min: 2,
                                max: 50,
                                message: 'Student first name must be more than 2 and less than 50 characters long'
                            },
                            regexp: {
                                regexp: /^[a-z]+$/i,
                                message: 'Student first name can consist of alphabetical characters only'
                            }

                        }
                    } , 
                    <%= inputStudentLastName.UniqueID %>: {
                        message: 'Student last name is not valid',
                        validators: {  
                            notEmpty: {
                                message: 'Student last name number is required'
                            },
                            stringLength: {
                                min: 2,
                                max: 50,
                                message: 'Student last name must be more than 2 and less than 50 characters long'
                            },
                            regexp: {
                                regexp: /^[a-z]+$/i,
                                message: 'Student last name can consist of alphabetical characters only'
                            }
                        }
                    }, 
                    <%= inputStudentCourse.UniqueID %>: {
                        message: 'Student course is not valid',
                        validators: {  
                            stringLength: {
                                min: 5,
                                max: 100,
                                message: 'Student course name must be more than 5 and less than 100 characters long'
                            }

                        }
                    }, 
                    <%= InputStudentYear.UniqueID %>: {
                        message: 'Student level is not valid',
                        validators: {  
                            stringLength: {
                                min: 1,
                                max: 20,
                                message: 'Student level be more than 1 and less than 20 characters long'
                            },
                            regexp: {
                                regexp: /^[a-z\s\-]+$/i,
                                message: 'Student level can consist of alphabetical characters,hyphen and spaces only'
                            }
                        }
                    }
                }
            });


      

            //validating fields on linking button click
            $("#submitButton").click(function(e){
                e.preventDefault();

                if (!$('#formValidator').data('bootstrapValidator').isValid()) 
                    $('#formValidator').bootstrapValidator('validate');
                if  (!$('#jobValidator').data('bootstrapValidator').isValid())
                    $('#jobValidator').bootstrapValidator('validate');
                if  (!$('#StudentValidator').data('bootstrapValidator').isValid())
                    $('#StudentValidator').bootstrapValidator('validate');

                if(($('#formValidator').data('bootstrapValidator').isValid()) & ($('#jobValidator').data('bootstrapValidator').isValid()) & ($('#StudentValidator').data('bootstrapValidator').isValid()))
                {
                    var clickButton = document.getElementById("<%=saveButton.ClientID %>");
                    //executing button click function
                    clickButton.click();
                }
            }); 
       
            // function that is called from c# to revalidate fields
            function checkBoxTicked()
            {
                if (!$('#formValidator').data('bootstrapValidator').isValid()) 
                    $('#formValidator').bootstrapValidator('validate');
                if  (!$('#jobValidator').data('bootstrapValidator').isValid())
                    $('#jobValidator').bootstrapValidator('validate');
            }
    </script>

</asp:Content>
