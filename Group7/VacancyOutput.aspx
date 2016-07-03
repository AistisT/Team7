<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VacancyOutput.aspx.cs" Inherits="Group7.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="h2 text-center">
            <asp:Label class="text-primary" ID="outputTitle" runat="server"></asp:Label>
        </div>
        <br />
        <div class="col-sm-6">
            <div class="form-group" runat="server">
                <label for="outputUniqueKey" class="col-sm-4 control-label text-primary">Vacancy reference number</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputUniqueKey">
                        <asp:Label ID="lblVacancyReferenceNumber"  runat="server" Text="lblVacancyReferenceNumber"></asp:Label>
                    </div>
                </div>
                <div id="positionGroup" runat="server">
                    <label for="outputPosition" class="col-sm-4 control-label text-primary">Employee position</label>
                    <div class="col-sm-8">
                        <div class="well well-sm" id="outputPosition">
                            <asp:Label ID="lblEmployeePosition" runat="server" Text="lblEmployeePosition"></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="disciplineGroup" runat="server">
                    <label for="outputDiscipline" class="col-sm-4 control-label text-primary">Discipline</label>
                    <div class="col-sm-8">
                        <div class="well well-sm " id="outputDiscipline">
                            <asp:Label ID="lblJobField" runat="server" Text="lblJobField"></asp:Label>
                        </div>
                    </div>
                </div>
                <label for="outputContract" class="col-sm-4 control-label text-primary">Contract type</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputContract">
                        <asp:Label ID="lblContractType" runat="server" Text="lblContractType"></asp:Label>
                    </div>
                </div>
                <div id="hoursGroup" runat="server">
                    <label for="outputHours" class="col-sm-4 control-label text-primary">Hours a week</label>
                    <div class="col-sm-8">
                        <div class="well well-sm" id="outputHours">
                            <asp:Label ID="lblHours" runat="server" Text="lblHours"></asp:Label>
                        </div>
                    </div>
                </div>
                <label for="outputSalary" class="col-sm-4 control-label text-primary">Salary</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputSalary">
                        <asp:Label ID="lblSalary" runat="server" Text="lblSalary"></asp:Label>
                    </div>
                </div>
                <div id="yearGroup" runat="server">
                    <label for="outputYear" class="col-sm-4 control-label text-primary">Required student level</label>
                    <div class="col-sm-8">
                        <div class="well well-sm" id="outputYear">
                            <asp:Label ID="lblStudentLevel" runat="server" Text="lblStudentLevel"></asp:Label>
                        </div>
                    </div>
                </div>
                <label for="outputClosingData" class="col-sm-4 control-label text-primary">Closing date</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputClosingDate">
                        <asp:Label ID="lblClosingDate" runat="server" Text="lblClosingDate"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-sm-6">
            <div class="form-group">

                <label for="outputCompanyName" class="col-sm-4 control-label text-primary">Company name</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputCompanyName">
                        <asp:Label ID="lblCompanyName" runat="server" Text="lblCompanyName"></asp:Label>
                    </div>
                </div>
                <div id="sectorGroup" runat="server">
                    <label for="outputSector" class="col-sm-4 control-label text-primary">Company sector</label>
                    <div class="col-sm-8">
                        <div class="well well-sm" id="outputSector">
                            <asp:Label ID="lblCompanySector" runat="server" Text="lblCompanySector"></asp:Label>
                        </div>
                    </div>
                </div>
                <label for="outputContact" class="col-sm-4 control-label text-primary">Contact details</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputContact">
                        <div  id="contactNameGroup" runat="server">
                            <asp:Label ID="lblName" runat="server" Text="lblName"></asp:Label><br />
                        </div>
                        <asp:Label ID="lblEmail" runat="server" Text="lblEmail"></asp:Label><br />
                        <asp:Label ID="lblTelephone" runat="server" Text="lblTelephone"></asp:Label>
                    </div>
                </div>

                <label for="outputLocation" class="col-sm-4 control-label text-primary">Location</label>
                <div class="col-sm-8">
                    <div class="well well-sm" id="outputLocation">
                        <div  id="houseGroup" runat="server">
                            <asp:Label ID="lblHouseNr" runat="server" Text="lblHouseNr"></asp:Label><br />
                        </div>
                        <div id="streetGroup" runat="server">
                            <asp:Label ID="lblStreetName" runat="server" Text="lblStreetName"></asp:Label><br />
                        </div>

                        <asp:Label ID="lblTown" runat="server" Text="lblTown"></asp:Label><br />
                        <div  id="postcodeGroup" runat="server">
                            <asp:Label ID="lblPostcode" runat="server" Text="lblPostcode"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="form-group">
        <label for="outputJobDescription" class="col-sm-2 control-label text-primary">Job description</label>
        <div class="col-sm-10">
            <div class="well well-sm" id="outputJobDescription">
                <pre><asp:Label ID="lblJobDescription" runat="server" Text="lblJobDescription"></asp:Label></pre>
            </div>
        </div>
    </div>

</asp:Content>
