<%@ Page Title="Admin Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminSearch.aspx.cs" Inherits="Group7.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--cookie warning copyright-->
    <!-- Copyright (C) 2013 Good Code
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.-->
    <script type="text/javascript" id="cookiebanner" src="http://cookiebanner.eu/js/cookiebanner.min.js"></script>
    <!--end of cookie warning copyright-->

    <asp:Panel ID="searchPanel" runat="server" DefaultButton="searchButton1" CssClass="row">
        <div class="col-sm-6">
            <h3 class="text-primary">What:</h3>
            <input type="text" class="form-control" id="jobSearch" runat="server">
            <p class="text-muted">Job title, keywords, company, student surname</p>
        </div>
        <div class="col-sm-6">
            <h3 class="text-primary">Where:</h3>
            <div class="input-group">
                <input type="text" class="form-control" id="locationSearch" runat="server">
                <span class="input-group-btn">
                    <asp:LinkButton class="btn btn-default btn-primary" type="button" ID="searchButton1" runat="server" OnClick="searchExecuted" Text=" Search ">
                        <span class="glyphicon glyphicon-search" aria-hidden="true"></span> &nbsp;Search&nbsp;
                    </asp:LinkButton>
                </span>
            </div>
            <p class="text-muted">City</p>
        </div>
    </asp:Panel>
    <br />

    <div class="row">
        <div class="col-sm-12">
            <div id="connectWarning" hidden="hidden" runat="server">
                <h3 class="text-danger">Could not connect to database, please try again later.</h3>
            </div>
            <asp:ListView ID="searchListView" runat="server" OnPagePropertiesChanged="searchListPropertiesChanged">
                <AlternatingItemTemplate>
                    <a href="<%# ResolveClientUrl("~/EditForm.aspx?id=" + Eval("AdvertID").ToString()) %>" class="list-group-item">
                        <h4 class="list-group-item-heading"><b>
                            <asp:Label ID="VacancyTitleLabel" runat="server" class="text-success" Text='<%# Eval("VacancyTitle") %>' />
                        </b></h4>
                        <br />
                        <pre style="max-height: 110px;"><asp:Label ID="JobDescriptionLabel" runat="server" Text='<%# Eval("JobDescription") %>' Font-Size="Small" /></pre>
                        <br />
                        <table class="table">
                            <thead>
                                <tr class="text-warning">
                                    <th>Location:
                                        <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' /></th>
                                    <th>Salary:
                                        <asp:Label ID="SalaryLabel" runat="server" Text='<%# Eval("Salary") %>' /></th>
                                    <th>DatePosted:
                                        <asp:Label ID="DatePostedLabel" runat="server" Text='<%# Eval("PostingDate") %>' /></th>
                                    <th>Job Type:
                                        <asp:Label ID="JobTypeLabel" runat="server" Text='<%# Eval("Contract") %>' /></th>
                                </tr>
                            </thead>
                        </table>
                    </a>
                    <br />
                </AlternatingItemTemplate>

                <ItemTemplate>
                    <a href="<%# ResolveClientUrl("~/EditForm.aspx?id=" + Eval("AdvertID").ToString()) %>" class="list-group-item">
                        <h4 class="list-group-item-heading"><b>
                            <asp:Label ID="VacancyTitleLabel" runat="server" class="text-primary" Text='<%# Eval("VacancyTitle") %>' />
                        </b></h4>
                        <br />
                        <pre style="max-height: 110px;"><asp:Label ID="JobDescriptionLabel" runat="server" Text='<%# Eval("JobDescription") %>' Font-Size="Small" /></pre>
                        <br />
                        <table class="table">
                            <thead>
                                <tr class="text-danger">
                                    <th>Location:
                                        <asp:Label ID="TownLabel" runat="server" Text='<%# Eval("Town") %>' /></th>
                                    <th>Salary:
                                        <asp:Label ID="SalaryLabel" runat="server" Text='<%# Eval("Salary") %>' /></th>
                                    <th>DatePosted:
                                        <asp:Label ID="DatePostedLabel" runat="server" Text='<%# Eval("PostingDate") %>' /></th>
                                    <th>Job Type:
                                        <asp:Label ID="JobTypeLabel" runat="server" Text='<%# Eval("Contract") %>' /></th>
                                </tr>
                            </thead>
                        </table>
                    </a>
                    <br />
                </ItemTemplate>

                <EmptyDataTemplate>
                    <h3 class="text-muted">No results found, please try different search parameters.</h3>
                </EmptyDataTemplate>

                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server" style="">
                        <span runat="server" id="itemPlaceholder" />
                    </div>
                    <div style="">
                        <asp:DataPager ID="searchDataPager" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowPreviousPageButton="true" ShowNextPageButton="false" />
                                <asp:NumericPagerField ButtonCount="10" ButtonType="Button" />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowLastPageButton="true" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </div>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
