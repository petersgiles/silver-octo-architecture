# Domain

![Data structure](https://g.gravizo.com/svg?
@startuml;
!define Lookup(name,desc) class name as "desc" << (L,#AAFFAA) >>;
!define CoreEntity(name,desc) class name as "desc" << (E,#AAAAFF) >>;
CoreEntity(brief, "Brief");
CoreEntity(commitment, "Commitment");
CoreEntity(projectfunding, "Project Funding");
CoreEntity(programfunding, "Program Funding");
Lookup(fundingtype, "Funding Type");
Lookup(status, "Status");
Lookup(project, "Project");
Lookup(budget, "Budget");
Lookup(location, "Location");
Lookup(electorate, "Electorate");
Lookup(parliament, "Parliament");
Lookup(theme, "Theme");
Lookup(package, "Package");
Lookup(program, "Program");
Lookup(portfolio, "Portfolio");
Lookup(agency, "Agency");
Lookup(handlingadvice, "Handling Advice");
Lookup(authoritytype, "Authority Type");
commitment .. parliament;
commitment .. portfolio;
commitment .. brief;
commitment .. project;
commitment .. program;
commitment .. handlingadvice;
handlingadvice .. authoritytype;
budget .. project;
budget .. program;
package .. programfunding;
program .. programfunding;
program .. theme;
fundingtype .. programfunding;
fundingtype .. projectfunding;
project .. projectfunding;
project .. location;
project .. status;
portfolio .. agency;
agency .. program;
location .. electorate;
@enduml;
)

## Parliament

The House of Representatives has a maximum *term* of three years, but may be dissolved, in effect by the *government*, at any time. In this system the definition of parliament uses on House of Representatives terms  and describes the term of a government including the shutdown period prior to an election.

## Budget

Budgets are called by the year in which they are presented to Parliament and relate to a financial year that commences on the following 1 July and ends on 30 June of the following year, so that the 2019 budget brought down in May 2019 relates to the 2019/20 financial year (1 July 2019 – 30 June 2020, FY2020).

## Portfolio

A [portfolio](https://www.directory.gov.au/portfolios) is a minister's area of responsibility as a member of Cabinet. Within each portfolio there are one or more departments, agencies, government appointed boards, and/or other boards and structures.

- [Agriculture](https://www.directory.gov.au/portfolios/agriculture)
- [Attorney-General's](https://www.directory.gov.au/portfolios/attorney-generals)
- [Communications and the Arts](https://www.directory.gov.au/portfolios/communications-and-arts)
- [Defence](https://www.directory.gov.au/portfolios/defence)
- [Education](https://www.directory.gov.au/portfolios/education)
- [Employment, Skills, Small and Family Business](https://www.directory.gov.au/portfolios/employment-skills-small-and-family-business)
- [Environment and Energy](https://www.directory.gov.au/portfolios/environment-and-energy)
- [Finance](https://www.directory.gov.au/portfolios/finance)
- [Foreign Affairs and Trade](https://www.directory.gov.au/portfolios/foreign-affairs-and-trade)
- [Health](https://www.directory.gov.au/portfolios/health)
- [Home Affairs](https://www.directory.gov.au/portfolios/home-affairs)
- [Industry, Innovation and Science](https://www.directory.gov.au/portfolios/industry-innovation-and-science)
- [Infrastructure, Transport, Cities and Regional Development](https://www.directory.gov.au/portfolios/infrastructure-transport-cities-and-regional-development)
- [Parliamentary Departments](https://www.directory.gov.au/portfolios/parliamentary-departments)
- [Prime Minister and Cabinet](https://www.directory.gov.au/portfolios/prime-minister-and-cabinet)
- [Services Australia (Part of the Social Services Portfolio)](https://www.directory.gov.au/portfolios/services-australia-part-social-services-portfolio)
- [Social Services](https://www.directory.gov.au/portfolios/social-services)
- [Treasury](https://www.directory.gov.au/portfolios/treasury)
- [Veterans' Affairs (part of the Defence Portfolio)](https://www.directory.gov.au/portfolios/veterans-affairs-part-defence-portfolio)

## Departments and Agencies

[Government departments and agencies](https://www.directory.gov.au/departments-and-agencies) are grouped into 18 principal departments, each led by a secretary, director-general, or similarly-titled executive officer and comprising a number of portfolios covering specific policy areas across the department and allocated statutory authorities, trading enterprises, boards, councils and other public bodies. Agencies have varying levels of operational autonomy, and deliver one or more of frontline public services, administrative functions and law enforcement. Some are structured as for-profit corporations. Where there are multiple portfolios within a department, the Secretary may be accountable to a number of ministers.

## Commitment (Policy)

During the pre-parliament period a commitment may take the form of announceables (A positive-sounding news item suitable for public announcement; a sound bite.) to something more substantial issued through press releases. **Political commitment** should be seen as a driving force that stimulates the management cycle and would be converted into **policy** once a party is elected. Typically these are recorded as **red** or **blue** and are related to briefs.

