<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="AddRemoveCourse.aspx.cs" Inherits="AddRemoveCourse" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Select all completed courses and hit submit.</h2>
            </hgroup>
            <p>
                
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum"></a>
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="appBody" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>

    <asp:PlaceHolder ID="uiPlaceholder" runat="server">
    


    <table class="mytable" width="719" height="510" border="1" style="visibility: visible">
      <tbody class="mytable">
          
        <tr class="tableheader">
          <td class="auto-style1">Requirement Area</td>
          <td class="auto-style1">Sub Area / Topic</td>
          <td class="auto-style1"># credit hours</td>
          <td class="auto-style1">Courses</td>
          <td colspan="2" align="center" class="auto-style1" >Completed</td>
          
        </tr>
        <tr>
          <td rowspan="2">I. Communication</td>
          <td>English</td>
          <td>6</td>
          <td>ENGL U101, ENGL U102</td>
          <td ><asp:CheckBox ID="ENGLU101" runat="server" /></td>
          <td><asp:CheckBox ID="ENGLU102" runat="server" /></td>
        </tr>
        <tr>
          <td class="auto-style2">Speech</td>
          <td class="auto-style2">3</td>
          <td class="auto-style2">SPCH 201</td>
          <td colspan="2" align="center" class="auto-style2"><asp:CheckBox ID="SPCH201" runat="server" /></td>
          
          
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
          
        </tr>
        <tr>
          <td rowspan="3">II. MathematiCSCIU, Logic &amp; Natural Sciences</td>
          <td>MathematiCSCIU</td>
          <td>4</td>
          <td>Math U141, Math U142</td>
          <td><asp:CheckBox ID="MATHU141"  runat="server" /></td>
          <td><asp:CheckBox ID="MATHU142" runat="server" /></td>
        </tr>
        <tr>
          <td rowspan="2">Natural Science (w/lab)</td>
          <td>8</td>
          <td><asp:DropDownList ID="ns101DropBox" runat="server"></asp:DropDownList>
              
          </td>
          <td colspan="2"><asp:CheckBox ID="ns101" runat="server" /></td>
          
          
        </tr>
        <tr>
          <td>4</td>
          <td><asp:DropDownList ID="ns102DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="ns102" runat="server" /></td>
          
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
         
        </tr>
        <tr>
          <td>III. Information Technology</td>
          <td>Information Technology</td>
          <td>3</td>
          <td>CSCIU1500</td>
          <td colspan="2"><asp:CheckBox ID="CSCIU150" runat="server" /></td>
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
          <td rowspan="3">IV. Fine Arts, Humanities & History</td>
          <td>Fine Arts</td>
          <td>3</td>
          <td><asp:DropDownList ID="art101DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="art101" runat="server" /></td>
          
        </tr>
        <tr>
          <td>History</td>
          <td>3</td>
          <td><asp:DropDownList ID="his101DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="his101" runat="server" /></td>
        </tr>
        <tr>
          <td>Humanities</td>
          <td>3</td>
          <td><asp:DropDownList ID="hum101DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="hum101" runat="server" /></td>
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
          <td>V. Foreign Language & Culture</td>
          <td>Foreign Language</td>
          <td>3</td>
          <td><asp:DropDownList ID="for101DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="for101" runat="server" /></td>
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
        </tr>
        <tr>
          <td rowspan="2">VI. Social & Behavioral Sciences</td>
          <td rowspan="2">Social & Behavioral Sciences</td>
          <td>3</td>
          <td><asp:DropDownList ID="soc101DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="soc101" runat="server" /></td>
        </tr>
          <tr>
          <td>3</td>
           <td><asp:DropDownList ID="soc102DropBox" runat="server"></asp:DropDownList></td>
          <td colspan="2"><asp:CheckBox ID="soc102" runat="server" /></td>
        </tr>
        <tr>
          <td colspan="6">&nbsp;</td>
        </tr>
          
      </tbody>
    </table>

    <table class="mytable" width="719" height="510" border="1" style="visibility: visible">
        <tbody class="mytable">
        <tr class="tableheader">
            <td colspan="2">Core Major Requirements</td>
            <td>33</td>
            
        </tr>
        <tr class="tableheader">
            <td></td>
            <td>Credit Hours</td>
            <td>Completed</td>
        </tr>
        <tr>
            <td>CSCIU200: Computer Science I</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU200" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU210: Computer Organization</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU210"  runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU234: Visual BASIC Programming or CSCIU238: C++ Programming</td>
            <td>3</td>
                
            <td><asp:CheckBox ID="CSCIU234" runat="server" /></td>
        </tr>
           
            <tr>
            <td>CSCIU300: Computer Science II</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU300" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU310: Intro to Computer Architecture</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU310" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU321: Computer Science III</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU321" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU421: Design & Analysis of Algorithms</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU421" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU511: Operation Systems</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU511" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU530: Programming Language Structures</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU530" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU540: Software Engineering</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU540" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU599: Senior Seminar</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU599" runat="server" /></td>
        </tr>
            
            </tbody>
    </table>

        <table class="mytable" width="719" height="510" border="1" style="visibility: visible">
        <tbody class="mytable">
        <tr class="tableheader">
            <td colspan="2">General</td>
            <td>9</td>
            
        </tr>
        <tr class="tableheader">
            <td></td>
            <td>Credit Hours</td>
            <td>Completed</td>
        </tr>
        <tr>
            <td>CSCIU311: Information Systems Hardware and Software</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU311" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU314: Industrial Robotics</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU314"  runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU315: Networking Technology</td>
            <td>3</td>
                
            <td><asp:CheckBox ID="CSCIU315" runat="server" /></td>
        </tr>
           
            <tr>
            <td>CSCIU325: Fundamentals of Relational Database Management</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU325" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU355: Digital Forensics</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU355" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU370: Fundamental of Bioinformatics</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU370" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU399: Independent Study</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU399" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU412: Computer Networks I</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU412" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCI441: Experiential Learning in Computer Science</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCI441" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU450: E-Business Web Application Design</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU450" runat="server" /></td>
        </tr>
            <tr>
            <td>CSCIU455: Computer Security</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU455" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU456: Applied Cryptography</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU456" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU512: Computer Networks II</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU512" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU515: Wireless Networks</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU515" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU516: Distributed and Network Programming</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU516" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU520: Database System Design</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU520" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU521: Database Implementation, Application, and Administration</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU521" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU525: Knowledge Discovery and Data Mining</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU525" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU526: Data Mining for Computer Security</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU526" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU555: Advanced Computer Security and Information Assurance</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU555" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU556: Web Development Security</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU556" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU580: Introduction to Artificial Intelligence</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU580" runat="server" /></td>
        </tr>
               <tr>
            <td>CSCIU585: Introduction to Computer Vision</td>
            <td>3</td>
            <td><asp:CheckBox ID="CSCIU585" runat="server" /></td>
        </tr>

            
            </tbody>
    </table>


        <table class="mytable" width="719" border="1" style="visibility: visible">
        <tbody class="mytable">
        <tr class="tableheader">
            <td colspan="2">Supporting Courses</td>
            <td colspan="2">13-14</td>
            
        </tr>
        <tr class="tableheader">
            <td></td>
            <td>Credit Hours</td>
            <td colspan="2">Completed</td>
        </tr>
        <tr>
            <td>MATHU174: Elements of Discrete Mathematics</td>
            <td>3</td>
            <td colspan="2"><asp:CheckBox ID="MATHU174" runat="server" /></td>
        </tr>
            <tr>
            <td>MATHU315: Statistical Methods I</td>
            <td>3</td>
            <td colspan="2"><asp:CheckBox ID="MATHU315"  runat="server" /></td>
        </tr>
            <tr>
          <td>Natural Science (w/lab)</td>
          <td>4</td>
          <td><asp:DropDownList ID="ns103DropBox" runat="server"></asp:DropDownList>
          <td><asp:CheckBox ID="ns103" runat="server" />    
          </td>
          
          
          
        
            </tbody>
    </table>
    

    <asp:Button ID="btnSubmit" runat="server" Text="Add" OnClick="btnSubmit_Click" />
    <asp:Button ID="btnRemove" runat="server" Text="Remove"/>

  
        
</asp:PlaceHolder>

</asp:Content>





